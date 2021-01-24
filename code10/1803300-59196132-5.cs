    using(var session = _factory.OpenSession()) 
    {
        var q = session.Query<SomeEntity>()
                       .Where(s => s.IpAddressField.InetEquals(new StringClob("<large_string_here>")));
    
        // ...
    }
