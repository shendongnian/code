    public class BatchNumberPrintingVisitor
      : IProductManagementVisitor
    {
      public void Visit(IManagedByBatchNumber visitor)
      {
        Console.WriteLine($"Batch: {visitor.BatchNo}");
      }
      public void Visit(IManagedBySerialNumber visitor)
      { /* ignore */ }
    }
    
