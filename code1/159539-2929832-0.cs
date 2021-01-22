    class Program
    {
        static void Main(string[] args)
        {
            sinifD s = new sinifD();
            // call method3 on sinfiD
            s.method3();
        }
    }
    public  class sinifC
    {
       public  void method3()
        {
            Console.WriteLine("Deneme3");
        }
    }
    public class sinifD : sinifC
    {
        // sinifD inheritrs mehtod3 from sinifD
        // method 4 is protected, so only classes in the class hierachy see that method
        void method4()
        {
            Console.WriteLine("Deneme4");
        }
    }
