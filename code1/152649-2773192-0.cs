    public static class ExtensionMethods
    {
        public static object GetValueOrNull(this SqlDataReader, string key)
        {
            return Convert.IsDBNull(this[key]) ? (object)"null" : reader[key];
        }
    }
