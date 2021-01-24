    public class RoutingMealGenerator : MealGenerator
    {
       public override List<Meal> GenerateMeals(Customer customer)
       {
          if (customer.PreferredMeal == PreferredMeal.Vegetarian)
             return new VegetarianMealGenerator().GenerateMeals(customer);
          else if (customer.PreferredMeal == PreferredMeal.NonVegetarian)
             return new NonVegetarianMealGenerator().GenerateMeals(customer);
       }
    }
