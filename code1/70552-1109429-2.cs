        public sealed class XxxJoinFragment : JoinFragment
        {
            private readonly SqlStringBuilder _afterFrom;
            public XxxJoinFragment()
            {
                _afterFrom = new SqlStringBuilder();
            }
            private SqlStringBuilder AfterFrom
            {
                get { return _afterFrom; }
            }
            public override SqlString ToFromFragmentString
            {
                get { return _afterFrom.ToSqlString(); }
            }
            public override SqlString ToWhereFragmentString
            {
                get { return SqlString.Empty; }
            }
            public override void AddJoin(string tableName, string alias,
                string[] fkColumns, string[] pkColumns,
                JoinType joinType)
            {
                AddCrossJoin(tableName, alias);
            }
            public override void AddJoin(string tableName, string alias,
                string[] fkColumns, string[] pkColumns,
                JoinType joinType, string on)
            {
                AddJoin(tableName, alias, fkColumns, pkColumns, joinType);
            }
            public override void AddCrossJoin(string tableName, string alias)
            {
                AfterFrom.Add(", ").Add(tableName).Add(" ").Add(alias);
            }
            public override void AddJoins(SqlString fromFragment, SqlString whereFragment)
            {
                AddFromFragmentString(fromFragment);
            }
            public override bool AddCondition(string condition)
            {
                return true;
            }
            public override bool AddCondition(SqlString condition)
            {
                return true;
            }
            public override void AddFromFragmentString(SqlString fromFragmentString)
            {
                AfterFrom.Add(fromFragmentString);
            }
        }
