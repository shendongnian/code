     public class Car
     {
         public virtual bool DetectHit() 
         { 
             detect if car bumped
             if bumped then activate airbag 
         }
     }
     
     public class SmartCar : Car
     {
         public override bool DetectHit()
         {
             bool isHit = base.DetectHit();
             if (isHit) { send sms and gps location to family and rescuer }
             
             // so the deriver of this smart car 
             // can still get the hit detection information
             return isHit; 
         }
     }
     public sealed class SafeCar : SmartCar
     {
         public override bool DetectHit()
         {
             bool isHit = base.DetectHit();
             if (isHit) { stop the engine }
             return isHit;
         }
     }
     
