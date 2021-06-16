/*
 *
 * (c) Copyright Ascensio System Limited 2010-2021
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
*/


namespace ASC.Common.Data.Sql.Expressions
{
    public class LGExp : Exp
    {
        private readonly SqlIdentifier column;
        private readonly bool equal;
        private readonly object value;

        public LGExp(string column, object value, bool equal)
        {
            this.column = (SqlIdentifier)column;
            this.value = value;
            this.equal = equal;
        }

        public override string ToString(ISqlDialect dialect)
        {
            return Not
                       ? string.Format("{0} >{1} ?", column.ToString(dialect), !equal ? "=" : string.Empty)
                       : string.Format("{0} <{1} ?", column.ToString(dialect), equal ? "=" : string.Empty);
        }

        public override object[] GetParameters()
        {
            return new[] { value };
        }
    }
}