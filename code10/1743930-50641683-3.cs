    public static class Extensions
    {
        public static string GetString<T>(this T e) where T : Exception
        {
            // dynamic method overload resolution is deferred at runtime through late binding.
            return GetStringCore((dynamic)e);
        }
        static string GetStringCore(Exception e)
        {
            return "Standard!!!";
        }
        static string GetStringCore(TimeoutException e)
        {
            return "TimeOut!!!";
        }
        static string GetStringCore(InvalidOperationException e)
        {
            return "Invalid!!!";
        }
    }
