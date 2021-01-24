    public void UnitTest_Prove_That_Service_Can_Be_Created() 
    {
        var sut = new SystemUnderTest();
        var container = sut.GetContainer();
        var service = container.Resolve<IXService>();
        // Prove the IXService resolves to an XService - i.e. the registration
        // has the correct mapping.
        Assert.Type<XService>(service);
    }
