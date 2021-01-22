    public int X(Bar bar, string target)
    {
        object value = bar.GetType().GetField(target, BindingFlags.Public | BindingFlags.Instance).GetValue(bar);
        return (int)value * 2;
    }
