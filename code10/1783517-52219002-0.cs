    public interface ITest
    {
        void Method1(bool readMode, List<int> list);
        void Method2(bool readMode, List<int> list);
        void Method3(bool readMode, List<string> list);
    }
    [Test]
    public void Method1Test()
    {
        Mock<ITest> test = new Mock<ITest>();
        TestAnyMethod<ITest, int>(test, "Method1");
        TestAnyMethod<ITest, int>(test, "Method2");
        TestAnyMethod<ITest, string>(test, "Method3");
        test.VerifyAll();
    }
    private void TestAnyMethod<T, TItem>(Mock<ITest> test, string methodName)
    {
        // Arrange
        var type = typeof(T);
        var methodInfo = type.GetMethod(methodName);
        test.Setup(Verifiable<TItem>(type, methodInfo)).Verifiable();
        // Act
        // make verifying call via reflection:
        // object.Method#(true, new List<TItem> { .. }))
        methodInfo.Invoke(test.Object, new object[] {true, new List<TItem>{ default(TItem) } });
        // object.Method#(true, new List<TItem> { .. , .. })
        methodInfo.Invoke(test.Object, new object[] {true, new List<TItem> { default(TItem), default(TItem) } });
        // Assert
        test.Verify(VerifyReadMode<TItem>(type, methodInfo, true), Times.AtLeastOnce());
        test.Verify(VerifyReadMode<TItem>(type, methodInfo, false), Times.Never());
        test.Verify(VerifyListCount<TItem>(type, methodInfo, 0), Times.Never());
        test.Verify(VerifyListCount<TItem>(type, methodInfo, 2), Times.Once());
    }
    /// <summary>
    /// Returns x=>x.Method#(It.IsAny`bool`(), It.IsAny`List`int``()
    /// </summary>
    /// <param name="mockingType">The type that we mock</param>
    /// <param name="method">Verifying method</param>
    private Expression<Action<ITest>> Verifiable<T>(Type mockingType, MethodInfo method)
    {
        var readModeArg = Expression.Call(typeof(It), "IsAny", new []{ typeof(bool) });
        var listArg = Expression.Call(typeof(It), "IsAny", new[] { typeof(List<T>) });
        return Verify(mockingType, method, readModeArg, listArg);
    }
    /// <summary>
    /// Returns x=>x.Method#(<paramref name="readMode"/>, It.IsAny`List`int``()
    /// </summary>
    /// <param name="mockingType">The type that we mock</param>
    /// <param name="method">Verifying method</param>
    /// <param name="readMode"></param>
    private Expression<Action<ITest>> VerifyReadMode<T>(Type mockingType, MethodInfo method, bool readMode)
    {
        var readModeArg = Expression.Constant(readMode);
        var listArg = Expression.Call(typeof(It), "IsAny", new[] { typeof(List<T>) });
        return Verify(mockingType, method, readModeArg, listArg);
    }
    /// <summary>
    /// Returns x=>x.Method#(It.IsAny`bool`(), It.Is`List`int``(y=>y.Count == <paramref name="count"/>)
    /// </summary>
    /// <param name="mockingType">The type that we mock</param>
    /// <param name="method">Verifying method</param>
    private Expression<Action<ITest>> VerifyListCount<T>(Type mockingType, MethodInfo method, int count)
    {
        var readModeArg = Expression.Call(typeof(It), "IsAny", new[] { typeof(bool) });
        var listPrm = Expression.Parameter(typeof(List<T>), "y");
        var prop = Expression.Property(listPrm, typeof(List<T>), "Count");
        var equal = Expression.Equal(prop, Expression.Constant(count));
        var lambda = Expression.Lambda<Func<List<T>, bool>>(equal, "y", new [] { listPrm });
        var listArg = Expression.Call(typeof(It), "Is", new[] { typeof(List<T>) }, lambda);
            
        return Verify(mockingType, method, readModeArg, listArg);
    }
    /// <summary>
    /// Returns lambda expression for verifying <paramref name="method"/> with arguments
    /// </summary>
    /// <param name="mockingType">The type that we mock</param>
    /// <param name="method">Verifying method</param>
    /// <param name="readModeArg">Expression for verify readMode argument</param>
    /// <param name="listArg">Expression for verify list argument</param>
    private Expression<Action<ITest>> Verify(Type mockingType, MethodInfo method, Expression readModeArg, Expression listArg)
    {
        var prm = Expression.Parameter(mockingType, "x");
        var methodCall = Expression.Call(prm, method, readModeArg, listArg);
        Expression<Action<ITest>> expr = Expression.Lambda<Action<ITest>>(methodCall, "x", new[] { prm });
        return expr;
    }
