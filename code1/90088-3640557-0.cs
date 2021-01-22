        public static class Context
        {
            private static string ConnectString;
            public static string Connect
            {
                get { return ConnectString ?? DataFactory.instance; }
                set { ConnectString= value; }
            }
            private class DataFactory
            {
                static DataFactory() { }
                internal static readonly string instance
                       = EntLib.Data._getDefaultName;
            }
        } 
