    public IObservable<string> IterateObservable(IList<string> strings)
    {
        return strings
            .ToObservable()
            .Buffer(100) // IObservable<IList<string>>
            .SelectMany(item => item); // IObservable<string>
    }
 
