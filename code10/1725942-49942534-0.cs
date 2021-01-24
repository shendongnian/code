    [HttpPost]        
    public ActionResult Save(PurchaseInvoiceHeaderFormViewModel viewModel)
    {
     using (CustData Tcontext = new CustData())
     {
       using (DbContextTransaction transaction = 
                                           Tcontext.Database.BeginTransaction())
        { 
        try
        {
          Tcontext.PurchaseInvoiceHeader.Add(viewModel.PurchaseInvoiceHeader);
          Tcontext.SaveChanges();
          foreach (var Split in viewModel.Splits)
          {                                
            Tcontext.VehicleInformation.Add(Split.VehicleInformation);                                
            Split.VehicleStock.VehicleInformationId = Split.VehicleInformation.Id;            
            Tcontext.VehicleStock.Add(Split.VehicleStock);                                
            Split.PurchaseInvoiceSplits.VehicleStockId = Split.VehicleStock.Id;                                
         
            Split.PurchaseInvoiceSplits.PurchaseInvoiceNumberId = viewModel.PurchaseInvoiceHeader.Id;
            Tcontext.PurchaseInvoiceSplits.Add(Split.PurchaseInvoiceSplits);
            Tcontext.SaveChanges();
          }
         transaction.Commit();
       }
       catch (Exception ex)
       {
          Console.WriteLine("Error occurred." + ex);                       
       }
      }
     }
    return RedirectToAction("xxx", "xxx");            
    }
