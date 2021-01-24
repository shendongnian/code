    public class MyClass
    {
        static void Main(string[] args)
        {
            MyClass myObject = new MyClass();
            myObject.Increase();
            myObject.Print(); // output: 1, 1
            myObject = new MyClass(); // new instance => only static variables are stored in the class and will not be dismissed.
            myObject.Increase();
            myObject.Print(); // output 1, 2
        }
        private int NotStaticItem = 0; // one per instance/object
        private static int StaticItem = 0; // one per class
        public void Increase()
        {
            NotStaticItem++;
            StaticItem++;
        }
        public void Print()
        {
            Console.WriteLine("NotStaticItem: {0}", NotStaticItem);
            Console.WriteLine("StaticItem: {0}", StaticItem);
        }
    }
