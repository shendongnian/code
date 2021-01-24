    for (int i = 0; i < 5; i++)
    {
        int l = i;
        list.Add(j => j + l);
    }
    // Equivalent to :
    for (var i = 0; i < 5; i++)
    {
        var c = new Closure();
        c.i = i;
        list.Add(c.Fn);
    }
