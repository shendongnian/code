    public void Test(object o)
    {
        Console.WriteLine(o.GetType().ToString());
    }
		
    Action<string> foo;
    foo = Test;
    foo.Invoke("bar");
