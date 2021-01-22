    var i = new Wrapper(0), i2 = new Wrapper(0), i3 = new Wrapper(0);
    c.Fill(i, i2, i3);
    i.Value //your value here
    
    public static void Fill(this SomeClass c, params Wrapper[] p)
    {
        for (int i = 0; i < p.Length; i++)
        {
            p[i].Value = 1; //assigning
        }
    }
