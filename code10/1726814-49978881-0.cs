    /// <summary>
    /// Splits an array into sub-arrays of a fixed length. The last entry will only be as long as the amount of elements inside it.
    /// </summary>
    /// <typeparam name="T">Type of the array</typeparam>
    /// <param name="array">Array to split.</param>
    /// <param name="splitLength">Amount of elements in each of the resulting arrays.</param>
    /// <returns>An array of the split sub-arrays.</returns>
    public static T[][] SplitArray<T>(T[] array, Int32 splitLength)
    {
        List<T[]> fullList = new List<T[]>();
        Int32 remainder = array.Length % splitLength;
        Int32 last = array.Length - remainder;
        for (Int32 i = 0; i < array.Length; i += splitLength)
        {
            // Get the correct length in case this is the last one
            Int32 currLen = i == last ? remainder : splitLength;
            T[] currentArr = new T[currLen];
            Array.Copy(array, i, currentArr, 0, currLen);
            fullList.Add(currentArr);
        }
        return fullList.ToArray();
    }
