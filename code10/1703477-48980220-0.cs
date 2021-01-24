    public abstract class Vehicle {}
    public class Car : Vehicle {}
    public class Bike : Vehicle {}
    
    public void DoSomething<T>(T _vehicle) where T : Vehicle
    {
        // _vehicle can be an instance of Car or Bike
        
        if (_vehicle is Car _car)
            motorwayInfo.CheckMotorwayStatus();
        
        if (_vehicle is Bike _bike)
            cycleInfo.CheckCyclePathStatus();
    }
