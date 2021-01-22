    public class Car
    {
         public BrakeStrategy BrakeStrategy { get; set; }
         public void Brake()
         {
             this.BrakeStrategy.Brake();
         }
    }
    public class ABSBrakes : BrakeStrategy
    {
         public void Brake()
         {
            ... do antilock braking...
         }
    }
    var car = new Car { BrakeStrategy = new ABSBrakes(), ... };
    car.Brake();  // does ABS braking
