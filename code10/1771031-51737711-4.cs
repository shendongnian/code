         public class CustomerEntity : TableEntity
        {
            public CustomerEntity(string lastName, string firstName)
            {
                this.PartitionKey = lastName;
                this.RowKey = firstName;
            }
    
            public CustomerEntity() { } // must have
    
            public string Email { get; set; }
    
            public string PhoneNumber { get; set; }
       }
