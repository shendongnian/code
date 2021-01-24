    public static bool operator==(Tuple<T1, T2> obj1, Tuple<T1, T2> obj2)
    {
        if (ReferenceEquals(null, obj2))
            return false;
        if (obj1.GetHashCode() != obj2.GetHashCode())
        {
            return false;
        }
        return obj1.First == obj2.First && obj1.Second == obj2.Second;
    }
