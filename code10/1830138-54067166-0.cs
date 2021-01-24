    var query = checkItemInventory.Join(listCost,
    									inventory => inventory.Id,
    									cost => cost.Id,
    									(inventory, cost) => new { id = inventory.Id });
    
    var count = query.ToList().Count();
    var b = (count > 0);
