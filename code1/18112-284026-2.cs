    public static List<Int32> LocateSubset(Byte[] superSet, Byte[] subSet)
    {
        if ((superSet == null) || (subSet == null))
        {
           throw new ArgumentNullException();
        }
        if ((superSet.Length < subSet.Length) || (superSet.Length == 0) || (subSet.Length == 0))
        {
            return new List<Int32>();
        }
        var result = new List<Int32>();
        Int32 currentIndex = 0;
        Int32 maxIndex =  superSet.Length - subSet.Length;
        while (currentIndex < maxIndex)
        {
             Int32 matchCount = CountMatches(superSet, currentIndex, subSet);
             if (matchCount ==  subSet.Length)
             {
                result.Add(currentIndex);
             }
             currentIndex++;
             if (matchCount > 0)
             {
                currentIndex += matchCount - 1;
             }
        }
        return result;
    }
    
    private static Int32 CountMatches(Byte[] superSet, int startIndex, Byte[] subSet)
    {
        Int32 currentOffset = 0;
        while (currentOffset < subSet.Length)
        {
            if (superSet[startIndex + currentOffset] != subSet[currentOffset])
            {
                break;
            }
            currentOffset++;
        }
        return currentOffset;
    }
