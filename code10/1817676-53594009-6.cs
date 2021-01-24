        public interface IFooRepository
        {
            FooDto GetFirst();
        }
        public interface IDataSetFactory
        {
            DataSet GetDataSet(string spName, SqlParameter[] = null);
        }
