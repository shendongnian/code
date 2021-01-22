    foreach (int i in 1.To(10))
    {
        Console.WriteLine(i);    // 1,2,3,4,5,6,7,8,9,10
    }
    foreach (int i in 5.To(-9).Step(2))
    {
        Console.WriteLine(i);    // 5,3,1,-1,-3,-5,-7,-9
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
    public static IEnumerable<T> Step<T>(this IEnumerable<T> source, int step)
    {
        return source.Where((x, i) => (i % step) == 0);
    }
