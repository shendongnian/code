    public interface IInterface
    {
       int TestFunction(int c, int d);
    }
    public class TestClass : IInterface
    {
        public int A { get; set; }
        public int B { get; set; }
        //Other stuff...
    
        public int TestFunction(int c, int d)
        {
             //Other stuff...
             return c + d;
        }
    }
