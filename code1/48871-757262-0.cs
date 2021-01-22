    public static T operator -(T foo, T bar)
    {
        return (T)System.Convert.ChangeType(
                System.Convert.ToDecimal(foo)
                    -
                System.Convert.ToDecimal(bar),
                    typeof(T));
    }
