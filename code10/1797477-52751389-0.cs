    public static class SqlReaderExtention {
         public static T GetValue<T>(this SqlDataReader reader, string fieldName) {
            int columnIndex = reader.GetOrdinal(fieldName);
            if (reader.IsDBNull(columnIndex)) {
               return default(T);
            }
            return (T)reader.GetValue(columnIndex);
         }
     }
