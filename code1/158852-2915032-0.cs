    public class Car
    {
        private CarSettings settings;
         
        public Car(CarSettings settings) 
        {
            settings = settings ?? CarSettings.Default;
        }
        public string Color { get {return settings.Color;} }
    }
    
    public class CarSettings 
    {
         public string Color {get; private set;}
         public static CarSettings Default = new CarSettings {Color = "Red"};
    }
    
