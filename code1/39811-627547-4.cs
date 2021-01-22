       public abstract class Car: IIdentifiable 
       {
           // common attributes here
           ...
           ...
           ...
           public abstract void move();
           public long GetUniqueId()
           {
              // compute the tires, wheel, and any other attribute 
              // and generate an unique id here.
           }
       }
       public class ElectricCar: Car
       {
           public void move()
           {
             .....
           }
       }
       public class SteamCar: Car
       {
           public void move()
           {
             .....
           }
      }
