class Program
{
    class A
    {
        private int _x;
        public A(int x)
        {
            _x = x;
        }
        
        public static implicit operator int(A a)
        {
            return a._x;
        }
    }
    static void Main(string[] args)
    {
        A a = new A(3);
        Console.WriteLine(a);
    }
}
