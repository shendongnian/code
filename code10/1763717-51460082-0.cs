    namespace Vehicles
    {
    
    public class MotorBike
    {
     Engine Engine { get; set; }
     List<Tire> Tires {get; set; }
    }
    
    public class Car
    {
     Engine Engine { get; set; }
     List<Tire> Tires {get; set; }
    }
    
    public class CompactCar : Car
    {
    }
    
    public class Engine
    {
     List<Pistons> { get; set;}
     ...
    }
    
    public class DieselEngine : Engine 
    {
     ...
    }
    
    public class Tire
    {
     int Diameter {get; set;}
     ...
    }
    
    }
