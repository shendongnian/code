    public interface IVendor
    {
        string Name { get; set; }    
    }
    
    public interface IVendor<TC> : IVendor where TC : IAccount
    {
        IEnumerable<TC> Accounts { get; set; }
    }
    
    public interface IAccount
    {
        string Name { get; set; }
    }
    
    // no longer needs IVendor<TC> before it can be compiled
    public interface IAccount<TC> : IAccount where TC : IExecutionPeriod
    {
        IVendor Vendor{ get; set; }
        IEnumerable<TC> ExecutionPeriods { get; set; }
    }
