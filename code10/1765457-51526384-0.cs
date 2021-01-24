    class MySuperLogger : ILogger
    {
        void LogError(string message) { /* do something super */ }
        void LogInfo(string message) { /* do something super */ }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var dbMigrator = new DbMigrator(new MySuperLogger());
            dbMigrator.Migrate();
        }
    }
