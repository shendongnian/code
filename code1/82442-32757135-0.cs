    public static bool ChangeProperty<T>(this PropertyChangedEventHandler propertyChanged, ref T field, T value, object sender, [CallerMemberName] string propertyName = null)
    {
        if (Equals(field, value))
        {
            return false;
        }
        else
        {
            field = value;
            propertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
