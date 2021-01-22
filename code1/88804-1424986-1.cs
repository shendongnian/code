    public static class EnumUtils
    {
        public static Nullable<T> Parse<T>(string input)
        {
            if(Enum.GetNames(typeof(T)).Any(e => e.ToUpperInvariant() == input.ToUpperInvariant()))
            {
                return (T)Enum.Parse(typeof(T), input, false);
            }
            else
            {
                return null;
            }
        }
    }
