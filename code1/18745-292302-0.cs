    public void WriteSomePropertyValue(object target)
    {
        Console.WriteLine(target as dynamic).SomeProperty);
    }
    public void WriteSomeMethodValue(object target, int arg1, string arg2)
    {
        Console.WriteLine(target as dynamic).SomeMethod(arg1, arg2));
    }
