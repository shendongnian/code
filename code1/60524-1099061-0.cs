    public static T[] CloneSubArray<T>(this T[] data, int index, int length)
        where T : ICloneable
    {
        T[] result = new T[length];
        for (int i = 0; i < length; i++)
        { 
            var original = data[index + i];
            if (original != null)
                result[i] = (T)original.Clone();            
        return result;
    }
