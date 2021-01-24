    var stockManagedByBatch = new Stock
    {
      Product =  "A",
      Quantity = 1,
      Management = new BatchNumberManagement
      {
        BatchNo = 123456
      }
    };
        
    var stockManagedByBatchAndSerialNo = new Stock
    {
      Product = "B",
      Quantity = 1,
      Management = new CompositeProductManagement(
        new BatchNumberManagement { BatchNo = 123456 },
        new SerialNumberManagement { SerialNo = 9870 }
      }
    };
    
    var stocks = new [] { stockManagedByBatch, stockManagedByBatchAndSerialNo };
    
    // print batch# of all stocks managed by batch to console
    var printingVisitor = new BatchNumberPrintingVisitor();
    
    foreach (var stock in stocks)
    {
      stock.Management.Accept(printingVisitor);
    }
