    public CustomerEntity(string lastName, string firstName)
    { 
        this.PartitionKey = lastName;
        this.RowKey = firstName;
    }
