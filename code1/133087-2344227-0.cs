    private static ObservableCollection<T> CreateObservable<T>(IEnumerable<T> enumerable)
    {
        return new ObservableCollection<T>(enumerable);
    }
    static void Main(string[] args)
    {
        var oc = CreateObservable(args.Where(s => s.Length == 5));
    }
