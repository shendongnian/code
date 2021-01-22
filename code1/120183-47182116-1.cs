    public interface IThing
    {
        string Name { get; }
        ReadOnlyObservableCollection<int> Values { get; }
    }
