    public class CarConsumer
    {
       private Func<string, ICar> _createCar;
       public CarConsumer(Func<string, ICar> createCar= CarFactory.Create)
       {
         _createCar = createCar;
       }
       public void ICar GetRedCar()
       {
         var result = _createCar("Tesla");
         result.Color = Color.Red;
         return result;
       }
    }
