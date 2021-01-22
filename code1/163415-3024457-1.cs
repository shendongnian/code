    public static string GetString(int[] array, int startIndex, int length)
    {
        var subarray = new int[length];
        Array.Copy(array, startIndex, subarray, 0, length);
        return Encoding.ASCII.GetString(Array.ConvertAll(subarray, i => (byte)i));
    }
