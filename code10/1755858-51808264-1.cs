    public sealed class LogDataMigration : DbMigrationsConfiguration<LogDataContext>
    {
        public const string CONTEXT_KEY = "BalsamicSoftware.LogData";
        private static readonly HashSet<string> _InitializedConnections = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private static readonly object _LockProxy = new object();
        public LogDataMigration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = CONTEXT_KEY;
            SetSqlGenerator("MySql.Data.MySqlClient", new FixedMySqlMigrationSqlGenerator());
        }
    }
