    public class MyClass : InterfaceOne, InterfaceTwo
    {
        public void InterfaceMethod()
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
