     public interface ICar
     {
          void Drive( decimal velocity, Orientation orientation );
          void Shift( int gear );
          ...
     }
     public abstract class Car : ICar
     {
          public virtual void Drive( decimal velocity, Orientation orientation )
          {
              ...some default implementation...
          }
          public abstract void Shift( int gear );
    
          ...
     }
     public class AutomaticTransmission : Car
     {
           public override void Shift( int gear )
           {
              ...some specific implementation...
           }
     }
     public class ManualTransmission : Car
     {
           public override void Shift( int gear )
           {
              ...some specific implementation...
           }
     }
