    public class PizzaRepository : IPizzaRepository
    {
      private readonly PizzaDbContext _pizzaDbContext = null;
    
      public PizzaRepository(PizzaDbContext pizzaDbContext)
      {
        _pizzaDbContext = pizzaDbContext;
      }
      public async Task<int> AddEntityAsync( /* params */ )
      {
         PizzaContext.Pizzas.Add( /* pizza */)
         // ...
       }
    }
