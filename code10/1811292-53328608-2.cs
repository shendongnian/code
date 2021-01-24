    public PizzaService(IDbContextScopeFactory contextScopeFactory, IPizzaRepo pizzaRepo, IPizzaIngredientsRepo ingredientRepo)
    {
      _contextScopeFactory = contextScopeFactory;
      _pizzaRepo = pizzaRepo;
      _ingredientRepo = ingredientRepo;
    }
    
    public async Task SavePizza(PizzaViewModel pizza)
    {
      using (var contextScope = _contextScopeFactory.Create())
      {
        int pizzaRows = await _pizzaRepo.AddEntityAsync(pizza.Pizza);
        int ingredientRows = await _ingredientRepo.PutIngredientsOnPizza(
          pizza.Pizza.PizzaId,
          pizza.Ingredients.Select(x => x.IngredientId).ToArray());
    
        contextScope.SaveChanges();
      }
    }  
