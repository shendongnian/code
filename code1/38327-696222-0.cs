    class DataTableBuilder : ITypeHandlerCallback
    {
        public object GetResult(IResultGetter getter)
        {
            IDataReader reader = getter.DataReader;
            
            // (A) define whatever type you want to
            // (B) read rows from DataReader and populate your type from (A)
            while (reader.Read())
            {
                // iterate over the columns of the current row
                for (int i = 0; i < reader.FieldCount; i++)
                {
                   // populate your type from (A)
                }                    
            }
            return ...;   // return your type from (A)
        }
        
        // implement the other members of ITypeHandlerCallback
        // the implementation below actually worked for me
        public object NullValue { get { return null; } }
        public void SetParameter(IParameterSetter setter, object parameter) { }
        public object ValueOf(string s) { return s; }
    }
