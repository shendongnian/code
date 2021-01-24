    public static class SqlExtensions // needs to be in a static class
    {
        public static void AddWithValueAndNullCheck(this SqlParameterCollection collection, string parameterName, object value)
        {
            if (object == null)
            {
                collection.AddWithValue(parameterName, DBNull.Value);
            }
            else
            {
                collection.AddWithValue(parameterName, value);
            }
        }
    }
