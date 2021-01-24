    namespace Vehicles.Cars
    {
        public class CarBase
        {
             public string Make {get; set;}
             public int Year {get; set;}
             public string Model  {get; set;}
        }
        public class Toyota : CarBase
        {
        }
    }
    namespace Vehicles.Cars.Engines
    {
        public class DeiselEngine
        {
             public string Type {get; set;}
             public int Cylinder {get; set;}
        }
    }
