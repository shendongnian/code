    public static class DataRecordExtensions
    {
        public static byte GetByte(this IDataRecord record, string name)
        {
            return Get<byte>(record, name);
        }
        public static short GetInt16(this IDataRecord record, string name)
        {
            return Get<short>(record, name);
        }
        public static int GetInt32(this IDataRecord record, string name)
        {
            return Get<int>(record, name);
        }
        private static T Get<T>(IDataRecord record, string name)
        {
            try
            {
                return (T)record[name];
            }
            catch (InvalidCastException ex)
            {
                throw BuildMoreExpressiveException<T>(record, name, value, ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("column: " + name + " ex.Message, ex);
            }
        }
        private static InvalidCastException BuildMoreExpressiveException<T>(
            IDataRecord record, string name, 
            object value, InvalidCastException ex)
        {
            string exceptionMessage = string.Format(CultureInfo.InvariantCulture,
                "Could not cast from {0} to {1}. Column name '{2}' of {3} " + 
                "could not be cast. {4}",
                value == null ? "<null>" : value.GetType().Name, 
                typeof(T).Name, name, record.GetType().FullName, ex.Message);
            return new InvalidCastException(exceptionMessage, ex);
        }
    }
