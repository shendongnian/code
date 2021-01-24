        private static T LongToEnum<T>(long i)
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("...");
            }
            return (T)Enum.ToObject(typeof(T), i);
        }
