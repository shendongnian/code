    public class Destroyer
    {
       public override string ToString() => GetType().Name;
       
       ~Destroyer() => Console.WriteLine($"The {ToString()} destructor is executing.");
       // equivalent 
       ~Destroyer()
       {
           Console.WriteLine($"The {ToString()} destructor is executing.");
       }
    }
