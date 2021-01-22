    class Customer  
    {
        [Field(“id”)]
        public int? CustomerId;
    
        [Field(“name”)]
        public string CustomerName;
    }
...
    using (DataReader reader = ...)
    {    
       List<Customer> customers = reader.AutoMap<Customer>()
                                        .ToList();
    }
