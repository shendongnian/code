    public interface IFoo
    {
         void Display();
    }
    public interface IBar
    {
         void Display();
    }
    
    public class MyClass : IFoo, IBar
    {
        void IBar.Display()
        {
            Console.WriteLine("IBar implementation");
        }
        void IFoo.Display()
        {
            Console.WriteLine("IFoo implementation");
        }
    }
    
    public static void Main()
    {
        MyClass c = new MyClass();
        IBar b = c as IBar;
        IFoo f = c as IFoo;
        b.Display();
        f.Display();
        Console.ReadLine();
    }
