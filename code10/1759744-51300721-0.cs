    public static ImmutableArray<T> GetImmutableArray<T>(T[] arr)
    {
        var immutableArray = ImmutableArray.Create(new T[0]);
        var boxed = ((object) immutableArray);
        Type t = boxed.GetType();
        FieldInfo fi = t.GetField("array", BindingFlags.NonPublic | BindingFlags.Instance);
        fi.SetValue(boxed, arr);
        return (ImmutableArray<T>)boxed;
    }
