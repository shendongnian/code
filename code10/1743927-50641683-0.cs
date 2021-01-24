    public static class Extensions
    {
        public static string GetString<T>(this T e) where T : Exception
        {
            return GetString((dynamic)e);
        }
        static string GetString(Exception e)
        {
            return "Standard!!!";
        }
        static string GetString(TimeoutException e)
        {
            return "TimeOut!!!";
        }
    }
