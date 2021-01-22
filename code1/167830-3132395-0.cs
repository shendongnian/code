    // these are using linq methods
    var barcodes = stockMovementCtx.StockMaterials
                     .Where(s => s.barcode == Barcode && s.ownership == 1)
                     .Select(s => s.barcode);
    var amounts = stockMovementCtx.ActualAmountsByLocations
                    .Where(a => barcodes.Contains(a.ItemBarCode))
                    .FirstOrDefault();
    // if you would like to use the query expressions instead, here they are
    //var barcodes = from s in stockMovementCtx.StockMaterials
    //               where s.barcode = Barcode && s.ownership == 1
    //               select s.barcode;
    //var amounts = (from a in stockMovementCtx.ActualAmountsByLocations
    //              where barcodes.Contains(a.ItemBarCode.Contains)
    //              select a).FirstOrDefault();
    
    // helpful to use FirstOrDefault if you are not sure that the query will return a result
    if (amounts != null) {
      // change value
      amounts.IsCustomerItem = 1;
      // update database
      stockMovementCtx.SubmitChanges();
    }
                    
    
