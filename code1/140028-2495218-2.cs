    using (var context = new PrincipalContext( ContextType.Machine,
                                               "MyComputer",
                                               userid,
                                               password ))
    {
       ...
    }
