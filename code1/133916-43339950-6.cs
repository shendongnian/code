    [TestCase(42)]
    [TestCase("string")]
    [TestCase(double.Epsilon)]
    public void GenericTest<T>(object instance)
    {
        Console.WriteLine(instance);
    }
