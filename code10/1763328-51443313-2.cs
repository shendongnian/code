    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string abc = "HELLO";
                myfuncclass test = new myfuncclass();
                Console.WriteLine("My result: {0}", test.ClassB(abc));
                Console.Read();
            }
    
        }
    
       public class myfuncclass
        { 
            public string ClassB(string abc)
            {
                return abc;
            }
        }
    }
