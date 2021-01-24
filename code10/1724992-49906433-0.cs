    unitOfWork.PurchaseItemRepository.DataSet
          .Where(x => x.CompanyId == id).ToList()
          .GroupBy(x => x.PurchaseItemPrice.Id)
          .Select(x => x.Max(y => 
           new { y.WarehouseId, 
                 y.CompanyId, 
                 y.ProductId,
                 y.AvailableQuantity 
           }));
