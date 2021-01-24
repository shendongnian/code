    public abstract class Drink
    {
      // Fields should be private or protected, but the 
      // description field that was here is useless, and
      // even if it were here, it should be a constant, 
      // not a variable
      // Eliminate it.
      // public string description = "Generic drink";
      // Things that are logically properties should be
      // properties, not GetBlah methods.
      // In new versions of C# you can use compact syntax 
      // for properties.
      // In the decorator pattern the behaviour mutated by the
      // decorator should be virtual.
      public virtual string Description => "generic drink";
    }
    
    public abstract class DrinkDecorator : Drink
    {
      // The decorator must override the underlying implementation.
      public abstract override string Description { get; }
    }
    
    public class SecretIngredient : DrinkDecorator
    {
        Drink drink;
        public SecretIngredient (Drink drink)
        {
            this.drink = drink;
        }
        // Use interpolation.
        public override string Description =>
          $"{this.drink.Description}, SecretIngredient ";
    }
    
    public class Espresso : Drink
    {
        public Espresso()
        {
           // This is just wrong. We have a mechanism for overriding
           // behaviour so **use it**.
           //   description = "Espresso";
        }
        public override string Description => "Espresso";
    }
    
    
    [TestFixture]
    class TestClass
    {
        [Test]
        public void TestMethod()
        {
            Drink drink = new Espresso();
            System.Diagnostics.Debug.WriteLine(drink.Description);
            drink = new SecretIngredient (drink);
            System.Diagnostics.Debug.WriteLine(drink.Description);
        }
    }
