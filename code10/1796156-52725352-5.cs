    public interface IProductManagement
    {
      void Accept(IProductManagementVisitor visitor);
    }
    
    public interface IManagedByBatchNumber
      : IProductManagement
    {
      public int BatchNo { get; set; }      
    }
    
    public interface IManagedBySerialNumber
      : IProductManagement
    {
      public int SerialNo { get; set; }   
    }
    ... etc ...
    
    public interface IProductManagementVisitor
    {
      void Visit(IManagedByBatchNumber management);
      void Visit(IManagedBySerialNumber management);
      ...etc...
    }
