    public static void MutateEach(this IList<T> list, Func<T, T> mutator)
    {
        int count = list.Count;
        for (int n = 0; n < count; n++)
            list[n] = mutator(list[n]);
    }
