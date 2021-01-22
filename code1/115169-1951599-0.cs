    [ServiceContract]
    interface ICustomerService
    {
        [OperationContract]
        Customer LoadCustomerByID(int customerID);
    
        [OperationContract]
        List<Customer> LoadCustomersByCountry(string country);
    
        [OperationContract]
        int SaveCustomer(Customer customer);
    
        [OperationContract]
        int DeleteCustomer(int customerID);
    }
