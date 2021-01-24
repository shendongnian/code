    public static T Get<T>(this IDataRecord dataRecord, int ordinal, T defaultValue)
    {
        //Here i call my default generic extensionmethod
        T value = DatabaseAccessLibrary.Extensions.IDataRecordExtensions.Get<T>(dataRecord, ordinal, defaultValue);
        //Here is the extracode
        if (value != null)
        {
            if (typeof(T) == typeof(string))
            {
                //If the value is not null and typeof string, i encode the value with the characterset
                string correctedValue = Encoding.Default.GetString(Encoding.GetEncoding("ibm850").GetBytes(value.ToString()));
                return (T)Convert.ChangeType(correctedValue, typeof(T));
            }
        }            
        return value;
    }
