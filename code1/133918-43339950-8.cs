    [TestCaseGeneric("Some response", TypeArguments = new[] { typeof(IMyInterface), typeof(MyConcreteClass) }]
    public void MyMethod_GenericCall_MakesGenericCall<T1, T2>(string expectedResponse)
    {
        // whatever
    }
