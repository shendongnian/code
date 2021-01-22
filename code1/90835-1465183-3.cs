    class CustomerDTO  
    {
        [Field(“id”)]
        public int? CustomerId;
    
        [Field(“name”)]
        public string CustomerName;
    }
...
    using (DataReader reader = ...)
    {    
       List<CustomerDTO> customers = reader.AutoMap<CustomerDTO>()
                                        .ToList();
    }
