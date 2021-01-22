    public void DoSomething(params object[] parameters)
    {
    
    }
    
    var parameters = new object[]{"someValue", 5};
    DoSomething(parameters); // this way works
    DoSomething("someValue", 5); // so does this way
