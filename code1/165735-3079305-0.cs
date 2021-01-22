    public class Car {
       public static readonly int Wheels = 4;
       public static int Count {get;set;}
       public string Make {get;set;}
       public string Model {get;set;}
       public int Year {get;set;}
       public Car() { Car.Count = Car.Count + 1; }
       public string SoundOff(){
           return String.Format("I am only 1 out of {0} car{1}", 
                  Car.Count, (Car.Count > 0 ? "s" : String.Empty));
       }
    }
