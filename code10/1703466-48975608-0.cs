    class Vehicle
    {
        public abstract void Behave();
    }
    class Car : Vehicle
    {
        public override void Behave()
        {
            // Do something specific to a car
        }
    }
    class Bike : Vehicle
    {
        public override void Behave()
        {
            // Do something specific to a bike
        }
    }
    ...
    void Run(Vehicle vehicle)
    {
        vehicle.Behave();
    }
