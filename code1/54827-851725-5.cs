    private static Customer _CurrentCustomer;
    public static Customer GetCurrentCustomer()
    {
        if (null == _CurrentCustomer)
        {
            _CurrentCustomer = new Customer 
            {   FirstName = "Jim"
               , LastName = "Smith"
               , TimeOfMostRecentActivity = DateTime.Now 
             };
        }
             return _CurrentCustomer;
    }
