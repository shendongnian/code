    public static void Main(string[] args) {
    
        var container = new UnityContainer()
            .RegisterType<ICustomerService, CustomerService>()
            .RegisterType<CustomerController>();
        CustomerController c = container.Resolve<CustomerController>();
        c.Operation();
    
        //...
    }
