    abstract class MyBase
    {
        protected const int X = 10;
    }
    class Derived : MyBase
    {
        Derived()
        {
            Console.WriteLine(MyBase.X);
        }
    }
