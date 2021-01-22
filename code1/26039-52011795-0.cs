    public static string Repeat(this string value, int count)
    {
        var values = new char[count * value.Length];
        values.Fill(value.ToCharArray());
        return new string(values);
    }
    public static void Fill<T>(this T[] destinationArray, params T[] value)
    {
        if (destinationArray == null)
        {
            throw new ArgumentNullException("destinationArray");
        }
        if (value.Length > destinationArray.Length)
        {
            throw new ArgumentException("Length of value array must not be more than length of destination");
        }
        // set the initial array value
        Array.Copy(value, destinationArray, value.Length);
        int copyLength, nextCopyLength;
        for (copyLength = value.Length; (nextCopyLength = copyLength << 1) < destinationArray.Length; copyLength = nextCopyLength)
        {
            Array.Copy(destinationArray, 0, destinationArray, copyLength, copyLength);
        }
        Array.Copy(destinationArray, 0, destinationArray, copyLength, destinationArray.Length - copyLength);
    }
