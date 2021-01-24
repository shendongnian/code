    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new RepoModule(), /*some other modules here maybe?*/);
            //thousand of code lines later...
            var csvRepo = kernel.Get<ICsvRepo>();
            var data = FetchData(csvRepo);
            var sqlRepo = kernel.Get<ISqlRepo>();
            data = FetchData(sqlRepo);
            var oracleRepo = kernel.Get<IOracleRepo>();
            data = FetchData(oracleRepo);
        }
        static object[] FetchData(IRepo repo)
        {
            throw new NotImplementedException();
        }
    }
