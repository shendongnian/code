    public interface IValueOption : IOption
    {
        void SetValue(object value);
        object GetValue();
        object[] Values { get; }
    }
