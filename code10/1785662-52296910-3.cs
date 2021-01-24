    //3 of these.
    public class SqlEnging : IDbEngineSelector
    {
        public void Configure(string connectionString,IOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseSqlServer(connectionString);
        }
    }
