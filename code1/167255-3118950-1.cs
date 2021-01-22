    using System.Collections.Generic;
    using System.Windows;
    
    namespace TestApp
    {
        public partial class Window2 : Window
        {
            public Window2()
            {
                InitializeComponent();
    
                DataContext = new CarsVM();
            }
        }
    
        public class CarsVM
        {
            public CarsVM()
            {
                CarTypes = new Dictionary<string, List<Car>>();
    
                // You want to populate CarTypes from some model.
                CarTypes["sedan"] = new List<Car>() {new Car("Honda Accord"), new Car("Toyota Camry")};
                CarTypes["musclecar"] = new List<Car>() { new Car("Chevy Camaro"), new Car("Dodge Challenger") };
                CarTypes["suv"] = new List<Car>() { new Car("Chevy Tahoe") };
            }
    
            public Dictionary<string, List<Car>> CarTypes { get; private set; } 
        }
    
        public class Car
        {
            public Car(string name)
            {
                Name = name;
            }
            public string Name { get; set; }
        }
    }
