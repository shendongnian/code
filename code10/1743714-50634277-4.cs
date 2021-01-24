    static (IEnumerable<T>, IEnumerable<U>) JoinListTuples<T, U>(
        (IEnumerable<T>, IEnumerable<U>) a,
        (IEnumerable<T>, IEnumerable<U>) b)
    {
        return (a.Item1.Concat(b.Item1),
            b.Item2.Concat(b.Item2));
    }
