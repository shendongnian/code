    foreach (int i in 5.To(-9).Step(2))
    {
        Console.WriteLine(i);    // 5,3,1,-1,-3,-5,-7,-9
    }
    // ...
    public static IEnumerable<T> Step<T>(this IEnumerable<T> source, int step)
    {
        if (step == 0)
        {
            throw new ArgumentOutOfRangeException("step", "Param cannot be zero.");
        }
 
        return source.Where((x, i) => (i % step) == 0);
    }
