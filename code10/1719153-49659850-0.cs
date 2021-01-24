    static void Main(string[] args)
    {
        Console.WriteLine(string.Join(", ", Rebase(1, 3, 3, 4))); // 1, 2, 2, 3
        Console.WriteLine(string.Join(", ", Rebase(1, 3, 5, 6, 6))); // 1, 2, 3, 4, 4
    }
    static int[] Rebase(params int[] values)
    {
        // Array.Sort(values); // if not already sorted, and allowed to mutate
        int prev = values[0];
        var result = new int[values.Length];
        int val = result[0] = 1;
        for (int i = 1; i < values.Length; i++)
        {
            var current = values[i];
            if (current != prev)
            {
                val++;
                prev = current;
            }
            result[i] = val;
        }
        return result;
    }
