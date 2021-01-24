    int Method(Abc abc)
    {
        Dictionary<Abc, int> dictionary = new Dictionary<Abc, int>()
        {
            { Abc.A, 23 },
            { Abc.B, 68 },
            { Abc.C, 96 },
            { Abc.D, 57 },
            { Abc.E, 63 }
        };
        return dictionary
            .Where(kvp => kvp.Key != abc)  // filter where Abc is different
            .Sum(kvp => kvp.Value);        // sum all values after filtering
    }
