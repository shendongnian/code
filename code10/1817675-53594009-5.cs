        internal sealed class FooRepository : IFooRepository
        {
            private readonly IDataSetFactory _dsFactory;
            public FooRepository(IDataSetFactory dsFactory)
            {
                _dsFactory = dsFactory;
            }
            public FooDto GetFirst()
            {
                return _dsFactory.GetDataSet("sp name")
                                 .Tables[0]
                                 .AsEnumberable()
                                 .Select(Map)
                                 .FirstOrDefault();
            }
            private FooDto Map(DataRow dr)
            {
                return new FooDto
                       {
                           CurrentCount = dr.Field<int>("CurrentCount"),
                           MaxCount = dr.Field<int>("MaxCount")
                       };
            }
        }
        internal sealed class DataSetFactory : IDataSetFactory
        {
            public DataSetFactory() { }
            private DataSet GetDataSet(string spName, SqlParameter[] = null)
            {
                //set up sql parameters, open connection
                return ds;
            }
        }
