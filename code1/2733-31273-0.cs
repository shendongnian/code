    abstract class Vehicle {
       public IList<Axle> Axles { get; set; }
    }
    class Motorcyle : Vehicle {
       public new IList<MotorcycleAxle> Axles { get; set; }
    }
    class Car : Vehicle {
       public new IList<CarAxle> Axles { get; set; }
    }
    void Main() {
       Vehicle v = new Car();
       // v.Axles is IList<Axle>
       Car c = (Car) v;
       // c.Axles is IList<CarAxle>
       // ((Vehicle)c).Axles is IList<Axle>
