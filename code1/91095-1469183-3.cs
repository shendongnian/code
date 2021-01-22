    public class HarleyExample
    {
        static public void Test()
        {
            Motorcycle a = new Motorcycle();
                HarleyDavidson b = new HarleyDavidson();
                Motorcycle c = new Motorcycle(); //Just a plain motorcycle
                a = b; // A Harley can be treated as a regular motorcycle
                //b = a; // Not just any motorcycle is a Harley
                Console.WriteLine("Is A a motorcycle?  " + (a is Motorcycle)); 
                Console.WriteLine("Is A a harley?      " + (a is HarleyDavidson));
                Console.WriteLine();
                Console.WriteLine("Is B a motorcycle?  " + (b is Motorcycle));
                Console.WriteLine("Is B a harley?      " + (b is HarleyDavidson));
                Console.WriteLine();
                Console.WriteLine("Is C a motorcycle?  " + (c is Motorcycle));
                Console.WriteLine("Is C a harley?      " + (c is HarleyDavidson));
                
                Console.ReadKey();
        }
    }
    public class Motorcycle
    {
        public void Cruise()
        {
            Console.WriteLine("Cruising");
        }
    }
    public class HarleyDavidson : Motorcycle
    {
        public void CruiseInStyle()
        {
            Console.WriteLine("Cruising in style on a Harley");
        }
    }
