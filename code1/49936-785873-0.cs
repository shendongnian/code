    var fake = Isolate.Fake.Instance<Proxy>(Members.ReturnRecursiveFakes);
    Isolate.WhenCalled(() => fake.CallService()).IgnoreCall();
    Isolate.Swap.NextInstance<Proxy>().With(fake);
    
    UnderTest classUnderTest = new ClassUnderTest();
    classUnderTest.MethodUnderTest(); // assuming the Proxy instance is used here.
    
    Isolate.Verify.WasCalledWithAnyArguments(()=>fake.CallService());
