    interface IVehicle{}
    class Car<T> : IVehicle {
        public static bool CheckType(IVehicle param)
        {
            return param is Car<T>;
        }
    }
...
    Car<string> c1 = new Car<string>();
    Car<int> c2 = new Car<int>();
    Console.WriteLine(Car<int>.CheckType(c1));
    Console.WriteLine(Car<int>.CheckType(c2));
