    foreach (int i in 1.To(10))
    {
        Console.WriteLine(i);    // 1,2,3,4,5,6,7,8,9,10
    }
    // ...
    public static IEnumerable<int> To(this int from, int to)
    {
        if (from < to)
        {
            while (from <= to)
            {
                yield return from++;
            }
        }
        else
        {
            while (from >= to)
            {
                yield return from--;
            }
        }
    }
