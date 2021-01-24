    var itemDtos = new List<ItemDto>();
    
    var inventoryItems = dbContext.InventoryItems.Where(x => x.InventoryCategoryId == categoryId).Select(x => new InventoryItemDto() {
        Attributes = x.Attributes,
        //.....
        // access brand columns
       // access company columns
       // access branch columns
       // access country columns
       // access state columns
    }).ToList();
    
    
    var inventorySpecifications = dbContext.InventoryCategorySpecifications
    .Where(x => x.InventoryCategoryId == categoryId)
    .OrderBy(x => x.DisplayOrder)
    .Select(x => x.InventorySpecification).ToList();
    
    
    
    foreach (var item in inventoryItems)
    {
        var specs = JObject.Parse(item.Attributes);
        // Assuming the specs become part of an inventory item?
        item.specs = inventorySpecification.Where(x => specs.ContainsKey(x.JsonKey)).Select(x => new SpecDto() { Key = x.JsonKey, Value = specs.GetValue(x.JsonKey)});
    }
