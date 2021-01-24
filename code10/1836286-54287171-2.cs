    var Bills = db.BillMasters
    .Select(x => new BillHomeViewModel
    {
        ConsumerCategory = db.ConsumerCategories
            .Where(c => c.ID == x.ConsumerCategory)
            .Select(c => c.CategoryName)
            .DefaultIfEmpty("")
            .FirstOrDefault()
    });
