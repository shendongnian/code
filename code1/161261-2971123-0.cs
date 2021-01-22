    //This is the car operations interface. It knows about all the different kinds of cars it supports
    //and is statically typed to accept only certain ICar subclasses as parameters
    public interface ICarVisitor {
       void StickAccelerator(Toyota car); //credit Mark Rushakoff
       void ChargeCreditCardEveryTimeCigaretteLighterIsUsed(Bmw car);
    }
    //Car interface, a car specific operation is invoked by calling PerformOperation  
    public interface ICar {
       public string Make {get;set;}
       public void PerformOperation(ICarVisitor visitor);
    }
    
    public class Toyota : ICar {
       public string Make {get;set;}
       public void PerformOperation(ICarVisitor visitor) {
         visitor.StickAccelerator(this);
       }
    }
    
    public class Bmw : ICar{
       public string Make {get;set;}
       public void PerformOperation(ICarVisitor visitor) {
         visitor.ChargeCreditCardEveryTimeCigaretteLighterIsUsed(this);
       }
    }
    public static class Program {
      public static void Main() {
        ICar car = carDealer.GetCarByPlateNumber("4SHIZL");
        ICarVisitor visitor = new CarVisitor();
        car.PerformOperation(visitor);
      }
    }
