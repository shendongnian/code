    public class Counter
    {
        public int Count { get; set; }
    }
    public static class CounterExtensions
    {
        public static IEnumerable<T> ObserveCount<T>
          (this IEnumerable<T> source, Counter count)
        {
            foreach (T t in source)
            {
                count.Count++;
                yield return t;
            }
        }
        public static IEnumerable<T> ObserveCount<T>
          (this IEnumerable<T> source, IList<Counter> counters)
        {
            Counter c = new Counter();
            counters.Add(c);
            return source.ObserveCount(c);
        }
    }
    public static class CounterTest
    {
        public static void Test1()
        {
            IList<Counter> counters = new List<Counter>();
      //
            IEnumerable<int> step1 =
                Enumerable.Range(0, 100).ObserveCount(counters);
      //
            IEnumerable<int> step2 =
                step1.Where(i => i % 10 == 0).ObserveCount(counters);
      //
            IEnumerable<int> step3 =
                step2.Take(3).ObserveCount(counters);
      //
            step3.ToList();
            foreach (Counter c in counters)
            {
                Console.WriteLine(c.Count);
            }
        }
    }
