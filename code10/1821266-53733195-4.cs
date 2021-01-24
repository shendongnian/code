    // there is no formatting here, just dumping
    void Assert<T1, T2, T3>(bool condition, T1 a, T2 b, T3 c)
    {
        if (condition)
        {
            // note that string.Concat contains overloads 
            // for up to 4 strings, so you don't need to instantiate
            // a StringBuilder 
            var message = string.Concat(a, b, c);
        }
    }
    // This is probably taking it too far; usability is severely degraded for
    // what I would guess is a ~5% performance win.
    // It gets resolved as Assert<int, string, double>(bool, int, string, double),
    // and these parameters just get converted to string and concatenated.
    Assert(value1 > value2, value1, " was not greater than ", value2);
