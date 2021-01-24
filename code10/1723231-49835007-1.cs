    var foo = new Foo
    {
        SomeAttribute1 = 1,
        SomeAttribute2 = 2,
        Values = new Int32Collection(new int[] { 1, 2, 3 })
    };
    Console.WriteLine(XamlServices.Save(foo));
