    internal sealed class Configuration : DbMigrationsConfiguration<MyDbContext>
    {
        public Configuration()
        {
            CodeGenerator = new CustomMigrationCodeGenerator();
            // ...
        }
    }
