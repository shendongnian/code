    public class Car {
      public void Drive() { // Remove parameter; doesn't need to be static.
        Console.WriteLine("Driving a {0}", this.GetType());
      }
    }
