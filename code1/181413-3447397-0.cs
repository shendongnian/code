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
                int[] temp = new int[indexes.Length];
                Array.Copy(result, temp, result.Length);
                yield return temp;
    
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
