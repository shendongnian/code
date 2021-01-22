    public static int CountUntyped(this IEnumerable source) {
        int count = 0;
        foreach(object obj in source) { count++; }
        return count;
    }
    IEnumerable<T> source = ...
    Assert.AreEqual(typed.Count(), source.CountUntyped());
