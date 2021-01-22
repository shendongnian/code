    public static IEnumerable<int[]> Odometer(int[] indexes)
    {
        int[] result = new int[indexes.Length];
        for (int i = 0; i < indexes.Length; i++)
            result[i] = -1;
    
        int ptr = 0;
        while (ptr >= 0)
        {
            while (ptr < indexes.Length)
            {
                result[ptr++]++;
                continue;
            }
    
            ptr--;
            while (result[ptr] < indexes[ptr])
            {
                //HERE
                //Clones the array so you are returning a new array - thanks Jon, for improvement on the Array.Copy code.
                yield return result.ToArray();
    
                result[ptr]++;
            }
    
            result[ptr]--;
            while (result[ptr] == indexes[ptr] - 1)
            {
                result[ptr] = -1;
                ptr--;
                if (ptr < 0)
                    break;
            }
        }
    }
