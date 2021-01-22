    static void GetCustomersCallback(IEnumerable<Customer> customers, Exception ex) {
        //Do something...
    }
    //Elsewhere:
    GetCustomers(new Action<IEnumerable<Customer>,Exception>(GetCustomersCallback));
