        private static T IntegerToEnum<T>(int i)
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("...");
            }
            return (T)Enum.ToObject(typeof(T), i);
        }
