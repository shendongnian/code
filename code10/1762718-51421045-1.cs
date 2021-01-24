    class Program
    {
        static void Main(string[] args)
        {
            House house = new House();
            Child child = new Child();
            house.child_labour(child);
        }
    }
    public class Parent
    {
        public Parent()
        {
        }
        public void Oblige()
        {
            Console.WriteLine("Hello world");
        }
    }
    public class Child : Parent
    {
        public Child()
        {
        }
        public void Work()
        {
        }
    }
    public class House
    {
        public House()
        {
        }
        public void child_labour(Child child)
        {
            child.Oblige();
        }
    }
