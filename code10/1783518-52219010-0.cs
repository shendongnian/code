    // Helper function to get It.IsAny<T>() Expression
    public static System.Linq.Expressions.MethodCallExpression IsAny<T>()
    {
        return System.Linq.Expressions.Expression.Call(typeof(It).GetMethod("IsAny").MakeGenericMethod(typeof(T)));
    }
    
    // Helper function to check conditions for list.Count
    public static bool CheckProperties(System.Collections.IList list, int expected)
    {
        return list.Count == expected;
    }
    public void TestMethod1()
    {
        var test = Mock.Of<ITest>();
        Mock.Get(test).Setup(x => x.Method1(It.IsAny<bool>(), It.IsAny<List<int>>())).Verifiable();
        //do stuff
        // Method1 passed as parameter
        TestAnyMethod<int>(test, x => x.Method1);
    }
    public void TestAnyMethod<T>(ITest test, Func<ITest, Action<bool, List<T>>> methodToTest)
    {
        var type = typeof(ITest);
        var param = Expression.Parameter(type);
        var method = type.GetMethod(methodToTest(Mock.Of<ITest>()).Method.Name); // Method that will be tested
        //test.Verify(x => x.METHOD(true, It.IsAny<List<T>>()), Times.AtLeastOnce());
        var call = Expression.Call(param, method, Expression.Constant(true), IsAny<List<T>>());
        Mock.Get(test).Verify(Expression.Lambda<Action<ITest>>(call, param),Times.AtLeastOnce());
        //test.Verify(x => x.METHOD(true, It.IsAny<List<T>>()), Times.AtLeastOnce());
        call = Expression.Call(param, method, Expression.Constant(true), IsAny<List<T>>());
        Mock.Get(test).Verify(Expression.Lambda<Action<ITest>>(call, param), Times.AtLeastOnce());
        var propertiesParam = Expression.Parameter(typeof(List<T>));
        var checkPropertiesMethod = GetType().GetMethod("CheckProperties", BindingFlags.Public | BindingFlags.Static);
        
        // test.Verify(x => x.METHOD(It.IsAny<bool>(), It.Is<List<T>>(y => y.Count == 0)), Times.Never());
        var checPropertiesCall = Expression.Call(Expression.Constant(this), checkPropertiesMethod, propertiesParam, Expression.Constant(0));
        call = Expression.Call(param, method, TestUtils.IsAny<bool>(), TestUtils.Is<EditFieldProperties<T>>(Expression.Lambda<bool>(checPropertiesCall, propertiesParam)));
        Mock.Get(test).Verify(Expression.Lambda<Action<ITest>>(call, param), Times.Never());
        
        // test.Verify(x => x.METHOD(It.IsAny<bool>(), It.Is<List<int>>(y => y.Count == 2)), Times.Once());
        checPropertiesCall = Expression.Call(Expression.Constant(this), checkPropertiesMethod, propertiesParam, Expression.Constant(2));
        call = Expression.Call(param, method, TestUtils.IsAny<bool>(), TestUtils.Is<EditFieldProperties<T>>(Expression.Lambda<bool>(checPropertiesCall, propertiesParam)));
        Mock.Get(test).Verify(Expression.Lambda<Action<ITest>>(call, param), Times.Once());
        
    }
