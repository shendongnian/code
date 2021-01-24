    public int MaybeAddArray(int[] array)
    {
        if (!arrayMap.TryGetValue(array, out var index))
        {
            index = arrayMap.Count + 1;
            arrayMap[array] = index;
        }
        return index;
    }
