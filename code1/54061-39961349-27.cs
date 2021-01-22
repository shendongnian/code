    private void TestActivator()
    {
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < 1024 * 1024 * 10; i++)
        {
            var myObject = Activator.CreateInstance(typeof(MyClass), 10, "test message");
        }
        sw.Stop();
        Trace.WriteLine("Activator: " + sw.Elapsed);
    }
    private void TestReflection()
    {
        var constructorInfo = typeof(MyClass).GetConstructor(new[] { typeof(int), typeof(string) });
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < 1024 * 1024 * 10; i++)
        {
            var myObject = constructorInfo.Invoke(new object[] { 10, "test message" });
        }
        sw.Stop();
        Trace.WriteLine("Reflection: " + sw.Elapsed);
    }
    private void TestExpression()
    {
        var myConstructor = CreateConstructor(typeof(MyClass), typeof(int), typeof(string));
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < 1024 * 1024 * 10; i++)
        {
            var myObject = myConstructor(10, "test message");
        }
        sw.Stop();
        Trace.WriteLine("Expression: " + sw.Elapsed);
    }
    TestActivator();
    TestReflection();
    TestExpression();
