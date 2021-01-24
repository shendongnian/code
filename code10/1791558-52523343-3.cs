    public interface IWheel {
        double Radius { get; set; }
        double RPM { get; set; }
        void Spin();
        double GetLinearVelocity();
    }
    public class BasicWheel : IWheel {
       public double Radius { get; set; }
       public double RPM { get; set; }
       public void Spin(){ ... }
       public double GetLinearVelocity() { ... }   
    }
        
    public class Car {
        ...
        public Car(IWheel one, IWheel two, IWheel three, IWheel four){
        ...
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
