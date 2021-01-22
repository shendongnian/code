    public class Car
    {
        public Car(string make, string model)
        {
             this.make = make;
             this.model = model;
        }
    
    
        public Car (Car car):this(car.Make, Car.Model){}
    }
    
    public class SuperCar : Car
    {
      SuperCar(Car car): base(car){}
    }
