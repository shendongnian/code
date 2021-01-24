    public class Option<T> : IOption, IValueOption
    {
        object[] IValueOption.Values => Values.Cast<object>().ToArray();
        void IValueOption.SetValue(object value)
        {
            SetValue((T)value);
        }
        object IValueOption.GetValue()
        {
            return GetValue();
        }
       ...
    }
