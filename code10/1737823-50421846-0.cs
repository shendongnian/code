    public IActionResult Furniture(int id) {
    FurniturePickupViewModel model = new FurnitureViewModel();
        var categories = context.FurnitureCategories.ToList();
        var furniture = new List<FurnitureList>();
        var quantityListItems = new List<QuantityList>();
        foreach (var cat in categories)
        {
            cat.Furniture = context.Furniture.Where(f => f.FurnitureCategoryID == cat.ID).ToList();
            var quantityListItems = new List<QuantityList>(); 
            foreach(var item in cat.Furniture)
            {
                quantityListItems.Add(new QuantityList
                {
                    ID = item.ID,
                    Name = item.Name,
                    Quantity = 0
                });
                
            }
            furniture.Add(new FurnitureList
            {
                CategoryID = cat.ID,
                Furniture = quantityListItems
            });
        }
        model.Categories = furniture;
        return View(model);
    }
