    var keep = models.Select(m => new Model {
        ID = m.ID,
        Price = m.Price,
        Address = m.Address,
        Characteristics = m.Characteristics,
        Sizes = m.Sizes.Where(x => x > condition).ToList()
    });
