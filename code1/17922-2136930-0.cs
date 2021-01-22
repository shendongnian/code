    if (!_customComparisons.TryGetValue(prop.Name, out comparison))
    {
        // Check to see if the property type we are sorting by implements
        // the IComparable interface.
        Type interfaceType = prop.PropertyType.GetInterface("IComparable");
        if (interfaceType != null)
        {
            comparison = delegate(T t1, T t2)
                {
                    IComparable val1 = (IComparable)prop.GetValue(t1) ?? "";
                    IComparable val2 = (IComparable)prop.GetValue(t2) ?? "";
                    return val1.CompareTo(val2);
                };
        }
        else
        {
            // Last option: convert to string and compare.
            comparison = delegate(T t1, T t2)
                {
                    string val1 = (prop.GetValue(t1) ?? "").ToString();
                    string val2 = (prop.GetValue(t2) ?? "").ToString();
                    return val1.CompareTo(val2);
                };
        }
    }
