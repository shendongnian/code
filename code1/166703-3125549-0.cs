    RemoteService service = new RemoteService();  //generated class
    
    UsernameToken token = new UsernameToken(username, password, PasswordOption.SendPlainText);
    Policy policy = new Policy();
    policy.Assertions.Add(new UsernameOverTransportAssertion());
    
    service.SetClientCredential(token);
    service.SetPolicy(policy);
    
    var result = service.MethodCall();
