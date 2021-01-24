    public class MyContext : DbContext
    {
        private readonly string connectionString;
        public MyContext (string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connectionString);
        }
    }
    kernel.Bind<MyContext>.ToSelf().WithConstructorArgument("connectionString", "YourConnectionString");
