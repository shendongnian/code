    public static class ObjectExtensions
    {
        public static string NullSafeToString(this object input)
        {
            return  input == null ? null : input.ToString();
        }
    }
