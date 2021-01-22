    public interface ICar
    {
        string Make {get; set;}
        string Model {get; set;}
        void Display();
    }
    public class Car :ICar
    { 
        private string make;
        private string model;
        public Car(string make, string model)
        {
             this.make = make;
             this.model = model;
        }
        public virtual void Display()
        {
           Console.WriteLine("Make: {0}", make);
           Console.WriteLine("Model: {0}", model);
        }
        public string Make
        {
           get{return make;}
           set{make = value;}
        }
        public string Model
        {
           get{return model;}
           set{model = value;}
        }
    }
    
    public class SuperCar:ICar
    {
        private ICar car;
        private int horsePower;
        public SuperCar(ICar car)
        {
            this.car = car;
        }
        public string Make
        {
           get{return car.Make;}
           set{car.Make = value;}
        }
        public string Model
        {
           get{return car.Model;}
           set{car.Model = value;}
        }
        public int HorsePower
        {
           get{return horsePower;}
           set{horsepower = value;}
        }
        public override void Display()
        {
           car.Display();
           Console.WriteLine("I am a super car");
    }
