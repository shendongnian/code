    public class Boat : ITransportation
    {
       public void TakeMeThere(string destination) // From ITransportation
       {
           Console.WriteLine("Going to " + destination);
       }
    }
