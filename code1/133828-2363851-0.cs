    protected void SetProperty<T>(string name, ref Nullable<T> oldValue, Nullable<T> newValue) where T : struct, System.IComparable<T>
    {
        if (oldValue.HasValue != newValue.HasValue || (newValue.HasValue && oldValue.Value.CompareTo(newValue.Value) != 0))
        {
            oldValue = newValue;
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(name));
        }
    }
