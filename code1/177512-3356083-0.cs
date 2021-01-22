        public static TResult ParseEnum<TResult>(this string value, TResult defaultValue)
        {
            try
            {
                return (TResult)Enum.Parse(typeof(TResult), value, true);
            }
            catch (ArgumentException)
            {
                return defaultValue;
            }
        }
