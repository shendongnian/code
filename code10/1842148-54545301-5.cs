    public class CarConsumer
    {
       private ICarFactory _carFactory;
       public CarConsumer(ICarFactory carFactory)
       {
         _carFactory = carFactory;
       }
       public void ICar GetRedCar()
       {
         var result = _carFactory.Create("Tesla");
         result.Color = Color.Red;
         return result;
       }
    }
