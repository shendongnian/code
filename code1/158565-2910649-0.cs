    class Program
    {
        static void Main(string[] args)
        {            
            Person p = new Person();
            p.Name = "Class Lijo";
            Utilityclass.TestMethod(p);
            string classResult = p.Name;
            Console.WriteLine(classResult);
            Utilityclass.TestMethod2(ref p);
            classResult = p.Name;  // will bomb here           
            Console.WriteLine(classResult);
        }
    }
    public class Utilityclass
    {
        public static void TestMethod(Person k)
        {
            k.Name = "Changed";
            k = null;
        }
        public static void TestMethod2(ref Person k)
        {
            k.Name = "Changed Again!";
            k = null;
        }
    }
