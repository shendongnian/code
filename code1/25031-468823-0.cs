    class Test
    {
        int _myInt;
        public Test(int myInt)
        {
            _myInt = myInt;
        }
        public override string ToString()
        {
            return "My int = " + _myInt.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var Ctor = typeof(Test).GetConstructor(new Type[] { typeof(int) });
            var obj = Ctor.Invoke(new object[] { 10 });
            Console.WriteLine(obj);
        }
    }
