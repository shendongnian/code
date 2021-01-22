    // usage: new GenericDataReader(cm.ExecuteReader())
    //        ...Get<decimal?>(...);
    public class GenericDataReader : IDataReader
    {
        // IDataReader implementation
        public T Get<T>(int ordinal)
        {
            if (_dataReader.IsDBNull(ordinal))
                return default(T);
            else
                return (T)_dataReader.GetValue(ordinal);
        }
    }
