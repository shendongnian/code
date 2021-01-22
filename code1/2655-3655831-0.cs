    public static class EnumHelper
    {
        public static int[] ToIntArray<T>(T[] value)
        {
            int[] result = new int[value.Length];
            for (int i = 0; i < value.Length; i++)
                result[i] = Convert.ToInt32(value[i]);
            return result;
        }
        public static T[] FromIntArray<T>(int[] value) 
        {
            T[] result = new T[value.Length];
            for (int i = 0; i < value.Length; i++)
                result[i] = (T)Enum.ToObject(typeof(T),value[i]);
            return result;
        }
        internal static T Parse<T>(string value, T defaultValue)
        {
            if (Enum.IsDefined(typeof(T), value))
                return (T) Enum.Parse(typeof (T), value);
            int num;
            if(int.TryParse(value,out num))
            {
                if (Enum.IsDefined(typeof(T), num))
                    return (T)Enum.ToObject(typeof(T), num);
            }
            return defaultValue;
        }
    }
