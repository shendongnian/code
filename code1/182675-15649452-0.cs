    static void Main(string[] args)
    {
        Console.WriteLine("BaseClass.MyConst = {0}, ClassA.MyConst = {1}, ClassB.MyConst = {2}", BaseClass.MyConst, ClassA.MyConst, ClassB.MyConst);
        Console.ReadKey();
    }
    class BaseClass
    {
        public const int MyConst = 1;
    }
    class ClassA : BaseClass
    {
        public new const int MyConst = 2;
    }
    class ClassB : BaseClass
    {
    }
