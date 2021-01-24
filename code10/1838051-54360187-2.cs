     public class Bike : Car, IVehicle
     {
          public void Manufacture()
         {
         Console.WriteLine("Bike Manufacturing");
         }
         int i = 1000; //some propertys needed to calculate alghoritm
         // method in vehicle class that we use to strategy, to edit our alghoritm
         public int CaluculateFuelConsumption() => Strategy.FuelConsumption() - i;
         //We deleted Strategy, because abstract Car class have already Strategy
       }  
