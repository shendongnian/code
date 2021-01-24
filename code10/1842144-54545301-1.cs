    public class CarConsumer
    {
       public void ICar GetRedCar()
       {
         var result = CarFactory.Create("Tesla");
         result.Color = Color.Red;
         return result;
       }
    }
