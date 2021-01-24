    public void SomethingElse(dynamic foo)
    {
        var length = foo.length;
        for (var i = 0; i < length; ++i)
        {
            var my = (MyType)foo[i];
            Console.WriteLine("{0} {1}", my.Foo, my.Bar);
        }
    }
