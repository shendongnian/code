    var authenticator = new KerberosAuthenticator(new KeyTable(File.ReadAllBytes("sample.keytab")));
    
    var identity = authenticator.Authenticate("YIIHCAYGKwYBBQUCoIIG...");
    
    Assert.IsNotNull(identity);
    
    var name = identity.Name;
    
    Assert.IsFalse(string.IsNullOrWhitespace(name));
