    public class PizzaRepository : IPizzaRepository
    {
      private readonly IAmbientDbContextLocator _contextLocator = null;
    
      private PizzaContext PizzaContext
      {
        get { return _contextLocator.Get<PizzaContext>(); }
      }
    
      public PizzaRepository(IDbContextScopeLocator contextLocator)
      {
        _contextLocator = contextLocator;
      }
      public async Task<int> AddEntityAsync( /* params */ )
      {
         PizzaContext.Pizzas.Add( /* pizza */)
         // ...
       }
    }
