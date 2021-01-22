    [ComVisible(true)]
    public interface IBake
    {
       Pastry Bake();
    }
    
    public class Baker<Recipe> : IBake
    {
       public Baker(Recipe ingredients) {...}
    
       public Pastry Bake()
       {
          ...
       }
    }
    
    [ComVisible(true)]
    public class Bakery
    {
       public IBake GetBaker(string recipe)
       {
          // somehow get recipe type from string
          // and create and return Baker<Recipe>
          // Client can now call IBake.Bake().
       }
    }
