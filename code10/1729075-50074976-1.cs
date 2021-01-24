    public class PreferenceRoutingMealGenerator : MealGenerator
    {
       IIndex<PreferredMeal, MealGenerator> _serviceLookup;
    
       public PreferenceRoutingMealGenerator( IIndex<PreferredMeal, MealGenerator> serviceLookup )
       {
          _serviceLookup = serviceLookup;
       }
    
       public override List<Meal> GenerateMeals(Customer customer)
       {
          MealGenerator gen = _serviceLookup[customer.PreferredMeal];
    
          return gen.GenerateMeals(customer);
       }
    }
