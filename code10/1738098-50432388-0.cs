    private void Test(ref int i)
    {
        Console.WriteLine(i);
        i++;
    }
    private void Test2(out int i)
    {
        i = 1000;
    }
    public void Method()
    {
        Type[] types = { typeof(int).MakeByRefType() };
        MethodInfo methodInfo = GetType().GetMethod(nameof(Test), BindingFlags.NonPublic | BindingFlags.Instance, null, types, null);
        int num = 10;
        var pars = new object[] { num };
        methodInfo.Invoke(this, pars);
        Console.WriteLine(pars[0]);
        MethodInfo methodInfo2 = GetType().GetMethod(nameof(Test2), BindingFlags.NonPublic | BindingFlags.Instance, null, types, null);
        var pars2 = new object[1];
        methodInfo2.Invoke(this, pars2);
        Console.WriteLine(pars2[0]);
    }
