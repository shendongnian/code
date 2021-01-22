    public class Service1 : IService1
    {
        public Car GetCar(string id)
        {
            return new Car { ID = int.Parse(id), Make = "Porsche" };
        }
        public Car UpdateCar(string f, Car car)
        {
            return car;
        }
    }
