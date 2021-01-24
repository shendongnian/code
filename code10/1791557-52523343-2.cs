    public class Wheel {
       public double Radius { get; set; }
       public double RPM { get; set; }
       public void Spin(){ ... }
       public double GetLinearVelocity() { ... }
    }
    
    public class LinearMovement{
       public double Velocity { get; set; }     
    }
    public class Car {
    
      private Wheel wheelOne;
      private Wheel wheelTwo;
      private Wheel wheelThree;
      private Wheel wheelFour;
      public Car(Wheel one, Wheel two, Wheel three, Wheel four){
        wheelOne = one;
        wheelTwo = two;
        wheelThree = three;
        wheelFour = four;
      } 
      public LinearMovement Move(){
        wheelOne.Spin();
        wheelTwo.Spin();
        wheelThree.Spin();
        wheelFour.Spin();
        speedOne = wheelOne.GetLinearVelocity();
        speedTwo = wheelTwo.GetLinearVelocity();
        speedThree = wheelThree.GetLinearVelocity();
        speedFour = wheelFour.GetLinearVelocity();
        return new LinearMovement(){ 
           Velocity = (speedOne + speedTwo + speedThree + speedFour) / 4
        };
      }
    }
  
