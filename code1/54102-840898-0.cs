    public abstract class Vehicle {}
    public class Car : Vehicle {}
    public class Truck : Vehicle {}
    public class VehicleFactory
    {
        public Vehicle CreateVehicle<T>() where T : Vehicle
        {
            // Get type of T and delegate creation to private methods
        }
    }
