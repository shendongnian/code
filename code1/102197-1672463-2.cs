    public static IEnumerable<TSubject> DistinctBy<TSubject, TValue>(this IEnumerable<TSubject> subjects, Func<TSubject, TValue> valueSelector)
    {
        var set = new HashSet<TValue>();
        foreach(var subject in subjects)
            if(set.Add(valueSelector(subject)))
                yield return subject;
    }
    var dictionary = list.DistinctBy(x => x.Name).ToDictionary(x => x.Name);
