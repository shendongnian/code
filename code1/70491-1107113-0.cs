    public interface I
    {
        void A();
    }
    public abstract class B : I
    {
        public void A( )
        {
            Console.WriteLine("Base");
        }
    }
    public class D : B
    {
        public void A()
        {
            Console.WriteLine("Hide");
        }
    }
    public class U
    {
        public void M(I i)
        {
            Console.WriteLine("M!");
        }
    }
