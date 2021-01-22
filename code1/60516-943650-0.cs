    public static T[] SubArray<T>(this T[] data, int index, int length)
    {
        T[] result = new T[length];
        Array.Copy(data, index, result, 0, length);
        return result;
    }
    static void Main()
    {
        int[] data = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] sub = data.SubArray(3, 4); // contains {3,4,5,6}
    }
