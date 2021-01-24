    public class ApplicationDbContext : DbContext
    {
        protected const string ConnectionStringName = "defaultConnection";
        public ApplicationDbContext() : base(ConnectionStringName)
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            Database.CommandTimeout = 300;
        }
