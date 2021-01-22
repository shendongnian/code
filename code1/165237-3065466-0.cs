     private Customer SetUpCustomerForRepository()
     {
        return new Customer()
        {
            CustId = 5,
            DifId = "55",
            CustLookupName = "The Dude",
            LoginList = new[] {
                new Login { LoginCustId = 5, LoginName = "tdude" } }
        };
     }
        
