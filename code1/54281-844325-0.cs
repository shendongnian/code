    public static void Do<T>(this IEnumerable<T> source, Action<T> action)
        where T : class
    {
        foreach (T item in source)
        {
            action(item);
        }
    }
    // ...
    public class Example
    {
        public int Value { get; set; }
    }
    // ...
    Example[] examples =
        {
            new Example { Value = 1 }, new Example { Value = 2 },
            new Example { Value = 3 }, new Example { Value = 4 }
        };
    examples.Do(x => x.Value *= 2);
    // displays 2, 4, 6, 8
    foreach (Example e in examples)
    {
        Console.WriteLine(e.Value);
    }
