    class Vehicle { }
    class Car : Vehicle { }
    class Program
    {
        static List<Car> ll = new List<Car>();
        static void Main(string[] args)
        {
           Vehicle[] v = ll.ConvertAll<Vehicle>(x => (Vehicle)x).ToArray();
        }
    }
