    public static class EnumEx
    {
        static public bool TryConvert<T>(int value, out T result)
        {
            result = default(T);
            bool success = Enum.IsDefined(typeof(T), value);
            if (success)
            {
                result = (T)Enum.ToObject(typeof(T), value);
            }
            return success;
        }
    }
