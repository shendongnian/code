    public static class EnumUtils
    {
        public static Nullable<T> Parse<T>(string input)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), input, false);
            }
            catch
            {
                return null;
            }
        }
    }
