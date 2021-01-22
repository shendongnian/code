    [TestCase(42)]
    [TestCase("string")]
    [TestCase(double.Epsilon)]
    public void GenericTest<T>(T instance)
    {
        Console.WriteLine(instance);
    }
