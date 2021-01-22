    using OX.Copyable;
    public static T[] DeepCopySubArray<T>(
        this T[] data, int index, int length)
    {
        T[] result = new T[length];
        for (int i = 0; i < length; i++)
        { 
            var original = data[index + i];
            if (original != null)
                result[i] = (T)original.Copy();            
        return result;
    }
