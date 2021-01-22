    public class A
    {
        public A(int myValue)
        {
            this.MyValue = myValue;
        }
        public int MyValue { get; private set; }
        public static implicit operator int(A a)
        {
            return a.MyValue;
        }
        public static implicit operator A(int value)
        {
            return new A(value);
        }
        // you would need to override .ToString() for Console.WriteLine to notice.
        public override string ToString()
        {
            return this.MyValue.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A t = 5;
            int r = t;
            Console.WriteLine(t); // 5
        }
    }
