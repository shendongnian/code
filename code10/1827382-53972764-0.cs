    public static class ReaderExtensions
    {
         public static string GetString(this SqlDataReader source, string fieldName)
         {
             return source.GetString(source.GetOrdinal(fieldName));
         }
    }
