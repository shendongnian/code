    // This seems reasonable ...
    public class Program
    {
       static void Main(string[] args)
       {
          Console.WriteLine("***** Fun with IEnumerable / IEnumerator *****\n");
          Garage carLot = new Garage();
          // Hand over each car in the collection?
          foreach (Car c in carLot)
          {
             Console.WriteLine("{0} is going {1} MPH",
             c.PetName, c.CurrentSpeed);
          }
          Console.ReadLine();
       }
    }
