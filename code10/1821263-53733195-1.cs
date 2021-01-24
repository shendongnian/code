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
