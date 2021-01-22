    public static void GetNumber(int start, int depth)
    {
        var count = GetNumber(start, depth, new Stack<int>());
        Console.WriteLine(count);
    }
    private static int GetNumber(int start, int depth, Stack<int> counters)
    {
        if (depth == 0)
        {
            Console.WriteLine(FormatCounters(counters));
            return 1;
        }
        else
        {
            var count = 0;
            for (int i = 0; i <= start; i++)
            {
                counters.Push(i);
                count += GetNumber(i, depth - 1, counters);
                counters.Pop();
            }
            return count;
        }
    }
