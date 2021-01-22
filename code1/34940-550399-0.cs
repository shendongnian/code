    public static class ObjectExtensions
    {
        public static string NullSafeToString(this object obj)
        {
            return obj != null ? obj.ToString() : String.Empty;
        }
    }
