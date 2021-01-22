    public static IEnumerable<T> SkipLastN<T>(this IEnumerable<T> source, int n) {
        var  it = source.GetEnumerator();
        bool hasRemainingItems = false;
        var  cache = new Queue<T>(n);
        do {
            if (hasRemainingItems = it.MoveNext()) {
                cache.Enqueue(it.Current);
                if (cache.Count > n)
                    yield return cache.Dequeue();
            }
        } while (hasRemainingItems);
    }
    static void Main(string[] args) {
        var Seq = Enumerable.Range(1, 4);
        Console.WriteLine(string.Join(", ", Seq.Select(x => x.ToString()).ToArray()));
        Console.WriteLine(string.Join(", ", Seq.SkipLastN(3).Select(x => x.ToString()).ToArray()));
    }
