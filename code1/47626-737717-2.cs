    public class SafeDataReader : IDataReader, ISafeDataRecord
    {
        /// <summary>
        /// Gets an integer from the datareader.
        /// </summary>
        /// <remarks>
        /// Returns 0 for null.
        /// </remarks>
        public int GetInt32(string name)
        {
            return GetInt32(_dataReader.GetOrdinal(name));
        }
        /// <summary>
        /// Gets an integer from the datareader.
        /// </summary>
        /// <remarks>
        /// Returns 0 for null.
        /// </remarks>
        public int GetInt32(int i)
        {
            if (_dataReader.IsDBNull(i))
                return 0;
            else
                return _dataReader.GetInt32(i);
        }
        public object this[string name]
        {
            get
            {
                object val = _dataReader[name];
                if (DBNull.Value.Equals(val))
                    return null;
                else
                    return val;
            }
        }
        public Nullable<T> GetNullable<T>(string name) where T:struct
        {
            int index = _dataReader.GetOrdinal(name);
            if (_dataReader.IsDBNull(index))
            {
                return null;
            }
            else
            {
                return new Nullable<T>((T)_dataReader[index]);
            }
        }
    }
