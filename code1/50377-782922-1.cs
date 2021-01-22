    interface ICar
    {
       IWheel Wheel {get; set;}
    }
    class FastCar: ICar
    {
       FastWheel FastWheel {get; set;}
       IWheel Wheel
       {
          get { return FastWheel; }
          set
          {
              if (value is FastWheel) FastWheel = (FastWheel)value;
          }    
       }         
    }
    class SlowCar: ICar
    {
       SlowWheel SlowWheel {get; set;}
       IWheel Wheel
       {
          get { return SlowWheel ; }
          set
          {
              if (value is SlowWheel ) SlowWheel = (SlowWheel )value;
          }    
       } 
    }
    class FastWheel: IWheel {}
    class SlowWheel: IWheel {}
