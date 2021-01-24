    public class VehicleManager
    {
      // boilerplate start
      private DoubleDispatchObject dispatch;
      public void DoSomething(Vehicle vehicle) =>
        this.EnsureThreadSafe(ref dispatch)
        .Via(nameof(DoSomething), vehicle, () => throw new NotImplementedException());
      // boilerplate end
      public void Run(Vehicle vehicle) =>
        DoSomething(vehicle);
      public void DoSomething(Car car) =>
        Console.WriteLine("Doing something with a car...");
      public void DoSomething(Bike bike) =>
        Console.WriteLine("Doing something with a bike...");
    }
    public abstract class Vehicle { }
    public class Car : Vehicle { }
    public class Bike : Vehicle { }
    class MainClass {
      public static void Main (string[] args) {
        var manager = new VehicleManager();
        manager.Run(new Car());
        manager.Run(new Bike());
        Console.WriteLine("Done.");
      }
    }
