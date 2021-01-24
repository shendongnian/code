    public class TheContext : DbContext
    {
        public TheContext()
        {
            this.Configuration.UseDatabaseNullSemantics = true;
        }
    }
