    public static int CountUntyped(this IEnumerable source) {
        int count = 0;
        foreach(object obj in source) count++;
        return count;
    }
    IEnumerable<T> typed = ...
    IEnumerable untyped = typed;
    Assert.AreEqual(typed.Count(), untyped.CountUntyped());
