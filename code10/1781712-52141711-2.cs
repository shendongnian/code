    public static bool Equals<TKey, TValue>(IDictionary<TKey, TValue> a, IDictionary<TKey, TValue> b, 
        IEqualityComparer<TKey> keyComparer, IComparer<TValue> valueComparer)
    {
        if (ReferenceEquals(a, b))
            return true;
        if (b == null || a == null)
            return false;
        if (a.Count != b.Count)
            return false;
        if (a.Keys.Any(x => !b.Keys.Contains(x, keyComparer)) ||
            b.Keys.Any(y => !a.Keys.Contains(y, keyComparer)))
            return false;
        foreach (TKey aKey in a.Keys)
        {
            TKey bKey = b.Keys.First(k => keyComparer.Equals(aKey, k));
            if (!b.TryGetValue(bKey, out TValue yVal))
                return false;
            if (valueComparer.Compare(a[aKey], yVal) != 0)
                return false;
        }
        return true;
    }
