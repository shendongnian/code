    public interface IVegetable {
       public float PricePerKilo {get;set;}
    }
    
    public class Potato : IVegetable {
       public float PricePerKilo {get;set;}
    }
    
    public class Tomato : IVegetable {
       public float PricePerKilo {get;set;}
    }
    
    public static class Program {
      public static void Main() {
        //All we get here is a string representing the class
        string className = "Tomato";
        Type type = this.GetType().Assembly.GetType(className); //reflection method to get a type that's called "Tomato"
        IVegetable veg = (IVegetable)Activator.CreateInstance(type);
      }
    }
