    public interface IRecipe {
       IEnumerable<Ingredient> Ingredients { get; }
    }
    public class Omlette : IRecipe {
       public IEnumerable<Ingredient> Ingredients { 
          get {
             return new Ingredient[]{new Ingredient("Salt"), new Ingredient("Egg")};
          }
       }
    }
    // etc. for your other classes.
    IRecipie FindRecipiesYouCanMake(IEnumerable<Ingredientes> stuff, Cook cook)
    {
        var query = Recipes.Where(r => !r.Ingredients.Except(stuff).Any());
        return query.First();
    }
    
