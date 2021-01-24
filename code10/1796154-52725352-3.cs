    public class BatchNumberManagement
      : IManagedByBatchNumber
    {
      public int BatchNo { get; set; }
      
      public void Accept(IProductManagementVisitor visitor)
      {
        visitor.Visit(this);
      }
    }
    
    public class SerialNumberManagement
      : IManagedBySerialNumber
    {
      public int SerialNo { get; set; }
      
      public void Accept(IProductManagementVisitor visitor)
      {
        visitor.Visit(this);
      }
    }
    
    public class CompositeProductManagement
      : IProductManagement
    {
      private readonly IEnumerable<IProductManagement> parts_; 
      
      public CompositeProductManagement(params IProductManagement[] parts)
      {
        parts_ = parts.ToArray();
      }
      
      public void Accept(IProductManagementVisitor visitor)
      {
        foreach (var part in parts_)
        {
          part.Accept(visitor);
        }
      }
    }
    
