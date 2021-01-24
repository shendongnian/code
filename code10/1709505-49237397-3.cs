    public void UnitTest_Prove_That_Service_Is_A_Singleton() 
    {
        var sut = new SystemUnderTest();
        var container = sut.GetContainer();
        var service1 = container.Resolve<IXService>();
        var service2 = container.Resolve<IXService>();
        // Prove you got the same service back each time - i.e. it's a singleton
        Assert.Equals(service1, service2);
    }
