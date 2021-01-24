    namespace ConsoltedeTEstes
      {
     class Program
     {
        static void Main(string[] args)
        {
            //Get the type of the car, be careful with the full name of class
            Type t = Type.GetType("ConsoltedeTEstes.Car");
            //Create a new object passing the parameters
            var dinamycCar = Activator.CreateInstance(t, "User", 2);
            //Get the method you want
            var method = ((object)dinamycCar).GetType().GetMethod("GetCarInfo");
            //Get the value of the method
            var returnOfMethod = method.Invoke(dinamycCar, new string[0]);
            Console.ReadKey();
        }
    }
    
    public class Car
    {
        public string Name { get; set; }
        public int Shifts { get; set; }
        public Car(string name, int shifts)
        {
            Name = name;
            Shifts = shifts;
        }
        public string GetCarInfo()
        {
            return "Car " + Name + " has number of shifts: " + Shifts;
        }
    }
    }
