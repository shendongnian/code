    public interface ICarFactory
    {
      void Register<TCar>(string car) where TCar : CarBase, new();
      ICar Create(string car);
    }
    public class CarFactory : ICarFactory
    {
      private readonly IDictionary<string, Type> CarsRegistry 
        = new Dictionary<string, Type>();
      public void Register<TCar>(string car) where TCar : CarBase, new()
      {
        if (!CarsRegistry.ContainsKey(car))
        {
          CarsRegistry.Add(car, typeof(TCar));
        }
      }
      public ICar Create(string car)
      {
        if (CarsRegistry.ContainsKey(car))
        {
          CarBase newCar = (CarBase)Activator.CreateInstance(CarsRegistry[car]);
          return newCar;
        }
        throw new NotSupportedException($"Unknown '{car}'");
      }
    }
