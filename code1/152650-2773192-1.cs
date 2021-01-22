    public static class ExtensionMethods
    {
        public static object GetValueOrNull(this SqlDataReader reader, string key)
        {
            return Convert.IsDBNull(reader[key]) ? (object)"null" : reader[key];
        }
    }
