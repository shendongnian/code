    IEnumerable<Grocery> query = Grocery
    
    if (Fruit != null)
    {
      query = query.Where(grocery =>
        Fruit.Any(fruit => fruit.FruitId == grocery.FruitId));
    }
    
    if (Vegetable != null)
    {
      query = query.Where(grocery =>
        Vegetable.Any(veggie => veggie.VegetableId == grocery.VegetableId));
    }
    
    List<Grocery> results = query.ToList();
