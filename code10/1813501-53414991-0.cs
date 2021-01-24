    public static class ExtentionMethods
    {
        public static T GetValue<T>(this DataRow row, string columnName, T defaultValue = default(T))
        {
            var obj = row[columnName];
            // if obj is DbNull it will skip this and return the default value
            if (obj is T)
            {
                return (T)obj;
            }
            return defaultValue;
        }
    }
