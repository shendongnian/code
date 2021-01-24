         Car GetCar(string make);
    }
    
    public interface IFindByModel
    {
         Car GetCar(string model);
    }
    public class Cars : IFindByMake, IFindByModel
    {
        internal List<Car> cars { get; set; }
        public Cars(List<Car> cars)
        {
            this.cars = cars;
        }
        Car IFindByMake.GetCar(string make)
        {
            foreach (Car car in cars)
            {
                if (car.make == make) return car;
            }
            return null;
        }
        Car IFindByModel.GetCar(string model)
        {
            foreach (Car car in cars)
            {
                if (car.model == model) return car;
            }
            return null;
        }
    }
