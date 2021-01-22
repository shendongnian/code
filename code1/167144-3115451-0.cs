    public class Model
        : IDataErrorInfo
    {
        public string this[string parameter]
        {
            get { /* Your current indexer */ }
        }
        string IDataErrorInfo.this[string columnName]
        {
            get { /* IDataErrorInfo indexer implementation */ }
        }
        /* ... */
    }
