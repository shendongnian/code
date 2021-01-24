    public class Program
    {
        public static void Main(string[] args)
        {
            var p = Person.Get(1);
    		
            var f = p.FirstName;
    		var l = p.LastName;
    		
    		Console.WriteLine("FirstName: "+ f);
    		Console.WriteLine("LastName: "+ l);
        }
    }
    //Produces:
    //  FirstName: Bob
    //  LastName: Jones
