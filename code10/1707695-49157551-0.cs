    public class CustomerProcessProxy : ICustomerProcess
    {
        private readonly ICustomerProcess retail;
        private readonly ICustomerProcess commercial;
        private readonly ICustomerContext context;
    
        // This constructor requires the two original implementations, and an ICustomerContext.
        // The ICustomerContext allows requesting information about 
        public CustomerProcessProxy(
            RetailCustomer retail, CommercialCustomer commercial, ICustomerContext context)
        {
            this.retail = retail;
            this.commercial = commercial;
            
            // Important note: in the constructor you should ONLY store incoming dependencies,
            // but never use them. That's why we won't call context.IsRetailCustomer here.
            this.context = context;
        }
        
        // ICustomerProcess methods
        // Each method will request the ICustomerProcess and forward the call to the
        // returned implementation.
        public object DoSomething(object input) => GetProcess().DoSomething(input);
        // Allows returning the correct ICustomerProcess based on runtime conditions.
        private ICustomerProcess GetProcess()
            => this.context.IsRetailCustomer ? this.retail : this.commercial;
    }
