        public sealed class XxxClientDriver : DriverBase
        {
            public override IDbConnection CreateConnection()
            {
                return XxxClientFactory.Instance.CreateConnection();
            }
            public override IDbCommand CreateCommand()
            {
                return XxxClientFactory.Instance.CreateCommand();
            }
            public override bool UseNamedPrefixInSql
            {
                get { return true; }
            }
            public override bool UseNamedPrefixInParameter
            {
                get { return true; }
            }
            public override string NamedPrefix
            {
                get { return "@"; }
            }
        }
