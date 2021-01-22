    public abstract class Animal {
      public abstract string Name { get; }
      public abstract bool CanFly { get; }
      public double Price { get; set; }
      // etc
    }
    public class Dog : Animal {
      public override string Name { get { return "Dog"; } }
      public override bool CanFly { get { return false; } }
      public Dog() { Price = 320.0; }
    }
    // etc
