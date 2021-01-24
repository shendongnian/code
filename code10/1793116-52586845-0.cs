    class ParentClass
    {
        public void Display()
        {
            Console.WriteLine("Display method in Parent class");//second get executed
        }
    }
    class ChildClass : ParentClass
    {
        public ChildClass(string x)//first get executed
        {
            Console.WriteLine(x);
        }
        public void Display1()
        {
            Console.WriteLine("Display method in Child class");
        }
    }
    public class Program
    {
        public static void Main()
        {
            ParentClass P = new ChildClass("First get Executed");
            P.Display();
            Console.ReadKey();
        }
    }
  
