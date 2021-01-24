            public class DatabaseConnections : IDatabaseConnections
            {
                public IEnumerable<Connection> OracleConnections { get; set; }
                public IEnumerable<Connection> MSSqlConnections { get; set; }
            }
