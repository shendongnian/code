    public class MyCompanyDataContextAdapter : MyCompanyDataContext
    {
        public MyCompanyDataContextAdapter(IDbConnection connection)
            : base(connection)
        { }
    }
