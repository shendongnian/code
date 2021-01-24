    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new RepoModule("foo", "bar"), /*some other modules here maybe?*/);
            //thousand of code lines later...
            var csvRepo = kernel.Get<ICsvRepo<MyEntity>>();
            var data = FetchData(csvRepo);
            var sqlRepo = kernel.Get<ISqlRepo<MyEntity>>();
            data = FetchData(sqlRepo);
            var oracleRepo = kernel.Get<IOracleRepo<MyEntity>>();
            data = FetchData(oracleRepo);
        }
        static T[] FetchData<T>(IRepository<T> repo)
        {
            throw new NotImplementedException();
        }
    }
