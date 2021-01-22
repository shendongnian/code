    protected bool SetProperty<T>(string name, ref T oldValue, T newValue) where T : System.IComparable<T>
        {
            if (oldValue == null || oldValue.CompareTo(newValue) != 0)
            {
                oldValue = newValue;
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(name));
                isDirty = true;
                return true;
            }
            return false;
        }
    // For nullable types
    protected void SetProperty<T>(string name, ref Nullable<T> oldValue, Nullable<T> newValue) where T : struct, System.IComparable<T>
    {
        if (oldValue.HasValue != newValue.HasValue || (newValue.HasValue && oldValue.Value.CompareTo(newValue.Value) != 0))
        {
            oldValue = newValue;
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(name));
        }
    }
