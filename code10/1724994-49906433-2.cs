     unitOfWork.PurchaseItemRepository.DataSet
          .Where(x => x.CompanyId == id).ToList()
          .GroupBy(x => x.PurchaseItemPrice)
          .Select(x => new {
            WarehouseId = x.OrderByDescending(v => v.WarehouseId).FirstOrDefault(),
            CompanyId = x.OrderByDescending(v => v.CompanyId).FirstOrDefault(),
            //Do the rest here 
          }).OrderBy( output => output.ProductId )
          .ToList();
  
