    using (TestLinq2Sql.Shared.SharedContext shared = 
        new TestLinq2Sql.Shared.SharedContext(
            ConfigurationManager.ConnectionStrings["myConnString"].ConnectionString))
    {
        var user = shared.Users.FirstOrDefault(u => u.Name == "test");
    }  
