    public class HarleyExample
    {
        static public void Test()
        {
            Motorcycle a = new Motorcycle();
            HarleyDavidson b = new HarleyDavidson();
            a = b; // A Harley can be treated as a regular motorcycle
            b = a; // Not just any motorcycle is a Harley
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
