    public interface IProductManagement
    {
      void Accept(IProductManagementVisitor visitor);
    }
    public interface IManagedByBatchNumber
      : IProductManagement
    {
      public int BatchNo { get; set; }      
    }
    public interface IProductManagementVisitor
    {
      void Visit(IProductManagement management);
    }
    public class BatchNumberPrintingVisitor
      : IProductManagementVisitor
    {
      void Visit(IProductManagement management)
      {
        var batchManagement = management as IManagedByBatchNumber;
        if (Object.ReferenceEquals(null, batchManagement))
          return;
        Console.WriteLine($"Batch number: {batchManagement.BatchNo}");
      }
    }
