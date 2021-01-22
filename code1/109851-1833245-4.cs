    public void Test(Object s)
    {
        Console.Out.WriteLine("Descendant.Test(Object=" + s + ")");
        Base b = this;
        b.Test((String)s);
    }
