    var fakeId = Isolate.Fake.Instance<IIdentity>();
    Isolate.WhenCalled(() => fakeId.AuthenticationType).WillReturn("Windows");
    Isolate.WhenCalled(() => fakeId.Name).WillReturn("TEST_USER");
    Isolate.WhenCalled(() => fakeId.IsAuthenticated).WillReturn(true);
    
    var fakePrinciple = Isolate.Fake.Instance<IPrincipal>();
    Isolate.WhenCalled(() => fakePrinciple.Identity).WillReturn(fakeId);
    
    var fakeContext = Isolate.Fake.Instance<HttpContext>();
    Isolate.WhenCalled(() => fakeContext.User).WillReturn(fakePrinciple);
