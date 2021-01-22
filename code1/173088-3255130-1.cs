    var x = 1;
    var y = 1;
    var z = 1;
    if (AllEqual(1, x, y, z))    // true
    if (AllEqual(2, x, y, z))    // false
    if (AllEqual(x, y, z))       // true
    var a = 1;
    var b = 2;
    var c = 3;
    if (AllEqual(a, b, c))       // false
    // ...
    public static bool AllEqual<T>(params T[] values)
    {
        if (values == null)
            throw new ArgumentNullException("values");
        if (values.Length < 1)
            throw new ArgumentException("Values cannot be empty.", "values");
        T value = values[0];
        for (int i = 1; i < values.Length; i++)
        {
            if (!value.Equals(values[i]))
                return false;
        }
        return true;
    }
