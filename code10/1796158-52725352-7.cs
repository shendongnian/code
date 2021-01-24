    public class BatchNumberPrintingVisitor
      : IProductManagementVisitor
    {
      public void Visit(IManagedByBatchNumber management)
      {
        Console.WriteLine($"Batch: {management.BatchNo}");
      }
      public void Visit(IManagedBySerialNumber management)
      { /* ignore */ }
    }
    
