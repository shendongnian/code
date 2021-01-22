    public static T[,] To2dArray(this List<List<T>> list)
    {
        if (list.Count == 0 || list[0].Count == 0)
            throw new ArgumentException("The list must have non-zero dimensions.");
    
        var result = new T[list.Count, list[0].Count];
        for(int i = 0; i < list.Count; i++)
        {
            for(int j = 0; j < list.Count; j++)
            {
                if (list[i].Count != list[0].Count)
                    throw new InvalidOperationException("The list cannot contain elements (lists) of different sizes.");
                result[i, j] = list[i][j];
            }
        }
    
        return result;
    }
