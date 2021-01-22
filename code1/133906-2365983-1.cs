    [Test]
    [TestCase(typeof(int), "my param", 20)]
    [TestCase(typeof(double), "my param", 123.456789)]
    public void TestParse(Type _type, object _param, object _expectedValue)
    {
        Type runnerType = typeof(TestRunner<>);
        var runner = Activator.CreateInstance(runnerType.MakeGenericType(_type));
        ((ITestRunner)runner).RunTest(_param, _expectedValue);
    }
