    public class Service1Client : ClientBase<IService1>, IService1
    {
        public Car GetCar(string id)
        {
            return base.Channel.GetCar(id);
        }
        public Car UpdateCar(string id, Car car)
        {
            return base.Channel.UpdateCar(id, car);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();
            Car car = client.GetCar("1");
            car.Make = "Ferrari";
            car = client.UpdateCar("1", car);
        }
    }
