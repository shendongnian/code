    public abstract class A
    {
        public void MethodC<TItem>(List<TItem> list) where TItem : A
        {
            foreach (var item in list)
                item.CanBeCalled();
        }
        public abstract void CanBeCalled();
    }
    public class B : A
    {
        public override void CanBeCalled()
        {
            Console.WriteLine("Calling into B");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<B> listOfB = new List<B>();
            A a = new B();
            a.MethodC(listOfB);
        }
    }
