    public class MyClass : InterfaceOne, InterfaceTwo
    {
        void InterfaceOne.InterfaceMethod()
        {
            Console.WriteLine("Which interface method is this?");
        }
    
        void InterfaceTwo.InterfaceMethod()
        {
            Console.WriteLine("Which interface method is this?");
        }
    }
    
    interface InterfaceOne
    {
        void InterfaceMethod();
    }
    
    interface InterfaceTwo
    {
        void InterfaceMethod();
    }
