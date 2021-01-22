    public static IEnumerable<T> TakeAllButLast<T>(this IEnumerable<T> source) {
        var it = source.GetEnumerator();
        bool hasRemainingItems = false;
        bool isFirst = true;
        T item = default(T);
        do {
            hasRemainingItems = it.MoveNext();
            if (hasRemainingItems) {
                if (!isFirst) yield return item;
                item = it.Current;
                isFirst = false;
            }
        } while (hasRemainingItems);
    }
    static void Main(string[] args) {
        var Seq = Enumerable.Range(1, 10);
        Console.WriteLine(string.Join(", ", Seq.Select(x => x.ToString()).ToArray()));
        Console.WriteLine(string.Join(", ", Seq.TakeAllButLast().Select(x => x.ToString()).ToArray()));
    }
