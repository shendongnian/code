    public PizzaService(PizzaDbContext context, IPizzaRepo pizzaRepo, IPizzaIngredientsRepo ingredientRepo)
    {
      _context = pizzaContext;
      _pizzaRepo = pizzaRepo;
      _ingredientRepo = ingredientRepo;
    }
    
    public async Task SavePizza(PizzaViewModel pizza)
    {
      int pizzaRows = await _pizzaRepo.AddEntityAsync(pizza.Pizza);
      int ingredientRows = await _ingredientRepo.PutIngredientsOnPizza(
        pizza.Pizza.PizzaId,
        pizza.Ingredients.Select(x => x.IngredientId).ToArray());
    
      _context.SaveChanges();
    } 
