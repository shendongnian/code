    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            this.Configuration.UseDatabaseNullSemantics = true;
        }
    }
