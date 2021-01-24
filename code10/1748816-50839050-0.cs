    public static void Main(string[] args) {
    
        var container = new UnityContainer();
        container.RegisterType<ICustomerService, CustomerService>();
        container.RegisterType<CustomerController>();
        CustomerController c = container.Resolve<CustomerController>();
        c.Operation();
    
        //...
    }
