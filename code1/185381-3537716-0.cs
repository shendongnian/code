    public static int GetOffsetOfArrayInArray(byte[] bigArray, int bigArrayOffset, int bigArrayCount, byte[] smallArray)
    {
        // TODO: Check whether none of the variables are null or out of range.
        if (smallArray.Length == 0)
            return 0;
        List<int> starts = new List<int>();    // Limited number of elements.
    
        int offset = bigArrayOffset;
        // A single pass through the big array.
        while (offset < bigArrayOffset + bigArrayCount)
        {
            for (int i = 0; i < starts.Count; i++)
            {
                if (bigArray[offset] != smallArray[offset - starts[i]])
                {
                    // Remove starts[i] from the list.
                    starts.RemoveAt(i);
                    i--;
                }
                else if (offset - starts[i] == smallArray.Length - 1)
                {
                    // Found a match.
                    return starts[i];
                }
            }
            if (bigArray[offset] == smallArray[0] &&
                offset <= (bigArrayOffset + bigArrayCount - smallArray.Length))
            {
                if (smallArray.Length > 1)
                    // Add the start to the list.
                    starts.Add(offset);
                else
                    // Found a match.
                    return offset;
            }
            offset++;
        }
        return -1;
    }
