    public IObservable<string> IterateObservable(IList<string> strings)
    {
        return strings
            .ToObservable()
            .Buffer(100)
            .SelectMany(list => list.ToObservable());
    }
