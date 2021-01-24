    public class Program
    {
        static void Main(string[] args)
        {
            var house = new House();
            var child = new Child();
            house.child_labour(child);
            Console.ReadKey();
        }
    }
    public class Parent
    {
        public void Oblige()
        {
           Console.WriteLine("CallOblige"); 
        }
    }
    public class Child : Parent
    {
        public void Work()
        {
            Console.WriteLine("Child Working");   
        }
    }
    public class House
    {
        
        public void child_labour(Child child)
        {
            child.Oblige();       
        }
    }
