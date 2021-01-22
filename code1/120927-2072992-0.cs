    public interface IFoo
    {
        void Bar();
    }
    
    public class FooBase
        : IFoo
    {
        public void Bar()
        {
            Console.WriteLine("FooBase");
        }
    }
    
    public sealed class SubFoo
        : FooBase//, IFoo
    {
        public new void Bar()
        {
            Console.WriteLine("SubFoo");
        }
    }
