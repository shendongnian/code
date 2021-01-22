    abstract class Vehicle<T> where T : Axle
    {
      public string Name;
      public List<T> Axles;
    }
    
    class Motorcycle : Vehicle<MotorcycleAxle>
    {
    }
    
    class Car : Vehicle<CarAxle>
    {
    }
    
    abstract class Axle
    {
      public int Length;
      public void Turn(int numTurns) { ... }
    }
    
    class MotorcycleAxle : Axle
    {
      public bool WheelAttached;
    }
    
    class CarAxle : Axle
    {
      public bool LeftWheelAttached;
      public bool RightWheelAttached;
    }
