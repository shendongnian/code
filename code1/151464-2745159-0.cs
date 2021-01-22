    public void DoSomething(string parameterA, int parameterB)
    {
      // Original do Something
    }
    public void DoSomething(object[] parameters)
    {
       // some contract check whether the parameters array has actually a good signature
       DoSomething(parameters[0] as string,(parameters[1] as int?).Value);
    }
    var parameters = new object[]{"someValue", 5};
    DoSomething(parameters);
