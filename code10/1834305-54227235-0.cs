    public static Expression<Func<T, bool>> RangeCompare<T, K>(Func<T, K> selector, IRangeValue<K> patten) where K : struct {
        var cmp = Comparer<K>.Default;
        Expression<Func<T, bool>> predicate = PredicateBuilder.True<T>();
        if (patten.GetHigh().HasValue)
            predicate = predicate.And<T>(s => cmp.Compare(selector(s), patten.GetHigh().Value) <= 0);
        if (patten.GetLow().HasValue)
            predicate = predicate.And<T>(s => cmp.Compare(selector(s), patten.GetLow().Value) >= 0);
        return predicate;
    }
