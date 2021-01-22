    public class DataHelperFactory
    {
        public IDataHelper Create()
        {
            ...
            var helper = new MySqlDataHelper(connectionString);
            return new SanitizingDataHelper(helper);
        }
    }
