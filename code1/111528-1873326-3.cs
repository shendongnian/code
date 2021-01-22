    var query = ord.Accumulate(
        new { Order = (OrderData)null, Total = 0.0 },
        (a, x) => new { Order = x, Total = a.Total + x.OrderAmount });
    foreach (var x in query)
    {
        Console.WriteLine("{0}\t{1}\t{2}\t{3}",
            x.Order.OrderNumber, x.Order.OrderDate, x.Order.OrderAmount, x.Total);
    }
    // ...
    public static class EnumerableExtensions
    {
        public static IEnumerable<TAccumulate> Accumulate<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (func == null)
                throw new ArgumentNullException("func");
            TAccumulate accumulator = seed;
            foreach (TSource item in source)
            {
                accumulator = func(accumulator, item);
                yield return accumulator;
            }
        }
    }
