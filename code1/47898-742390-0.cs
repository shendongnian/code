    public void MyTestMethod1()
    {
      string myVar = "Hello World";
      MyTestMethod2(() => myVar);
    }
    
    public void MyMethod2(Expression<Func<string>> func)
    {
      var localVariable = (func.Body as MemberExpression).Member.Name;
      // localVariable == "myVar"
    }
