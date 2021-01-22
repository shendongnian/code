     class Car
     {
         virtual bool DetectHit() 
         { 
             detect if car bumped, 
             if bumped then activate airbag 
         }
     }
     
     class SafeCar : Car
     {
         override bool DetectHit()
         {
             bool isHit = base.DetectHit();
             if (isHit) { stop engine }
             
             return isHit;          
         }
     }
     
