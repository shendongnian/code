    public interface ISum
    {
        int Sum(int a, int b);
    }
    
    public interface IMinus : ISum
    {
        int Minus(int a, int b);
    }
    
    public class FooClass: IMinus
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    
        public int Minus(int a, int b)
        {
            return a - b;
        }
    }
