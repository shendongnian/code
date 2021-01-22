     private static T GetEnum<T>(int v) where T : struct, IConvertible
        {
            if (typeof(T).IsEnum)
                if (Enum.IsDefined(typeof(T), v))
                {
                    return (T)Enum.ToObject(typeof(T), v);
                }
            throw new ArgumentException(string.Format("{0} is not a valid value of {1}", v, typeof(T).Name));
        }
