    IEnumerable<T> WhereWithDefault<T>(this IEnumerable<T> source,
                                       Predicate<T> primaryCondition,
                                       Predicate<T> fallbackCondition)
    {
        var fallback = new List<T>();
        bool foundPrimary = false;
        foreach( T t in source ) {
            if (primaryCondition(t)) { foundPrimary = true; fallback.Clear(); yield return t; }
            else if (!foundPrimary && fallbackCondition(t)) { fallback.Add(t); }
        }
        if (foundPrimary) yield break;
        foreach (T t in fallback) yield return t;
    }
    var loggedinUserCoupons = loggedinUser.Coupons
                                          .WhereWithDefault(x => x.StateId == loggedinUsers.StateID, x => x.StateId == null);
