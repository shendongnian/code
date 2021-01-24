        public void UpdatePricesFromInventoryList(IList<Domain.Tables.Inventory> invList)
    {
        var db = new UniStockContext();
        invIdsArray = invList.select(x => x.InventoryID).ToArray();
        IList<Domain.Tables.Inventory>  invListFromDbByOneHit = db.Inventories.Where(x => invIdsArray.Contains(x.InventoryID)).Tolist();
        foreach (var inventory in invListFromDbByOneHit)
        {
            //Domain.Tables.Inventory _inventory = db.Inventories
                                                //.Where(x => x.InventoryID == inventory.InventoryID)
                                                //.FirstOrDefault();
            if (inventory.Cost.HasValue)
                _inventory.Cost = inventory.Cost.Value;
            else
                _inventory.Cost = 0;
            foreach (var inventoryPrices in inventory.AccInventoryPrices)
            {
                foreach (var _inventoryPrices in _inventory.AccInventoryPrices)
                {
                    if (_inventoryPrices.AccInventoryPriceID == inventoryPrices.AccInventoryPriceID)
                    {
                        _inventoryPrices.ApplyDiscount = inventoryPrices.ApplyDiscount;
                        _inventoryPrices.ApplyMarkup = inventoryPrices.ApplyMarkup;
                        if (inventoryPrices.Price.HasValue)
                            _inventoryPrices.Price = inventoryPrices.Price.Value;
                        else
                            _inventoryPrices.Price = _inventory.Cost;
                        if (inventoryPrices.OldPrice.HasValue)
                        {
                            _inventoryPrices.OldPrice = inventoryPrices.OldPrice;
                        }
                    }
                }
            }
            db.Inventories.Attach(_inventory);
            db.Entry(_inventory).State = System.Data.Entity.EntityState.Modified;
        }
        db.SaveChanges();
        db.Dispose();
    }
