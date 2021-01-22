    public interface IMetaProperty<TValue>
    {
        TValue Value { get; set; }
        string DisplayName { get; }
        event Action<TValue, TValue> ValueChanged;
    }
