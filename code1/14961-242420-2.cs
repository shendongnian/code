    static void Main()
    {
        int[] x = { 1, 2, 3, 4, 5 };
        string[] y = { "abc", "def", "ghi", "jkl", "mno" };
        foreach (var item in x.Zip(y))
        {
            Console.WriteLine("{0}/{1}", item.Key, item.Value);
        }
    }
    // library code; written once and stuffed away in a util assembly...
    static IEnumerable<KeyValuePair<TLeft, TRight>> Zip<TLeft, TRight>(
        this IEnumerable<TLeft> left, IEnumerable<TRight> right)
    {
        using(IEnumerator<TLeft> leftE = left.GetEnumerator())
        using (IEnumerator<TRight> rightE = right.GetEnumerator())
        {
            while (leftE.MoveNext() && rightE.MoveNext())
            {
                yield return new KeyValuePair<TLeft, TRight>(
                    leftE.Current, rightE.Current);
            }
        }
    }
