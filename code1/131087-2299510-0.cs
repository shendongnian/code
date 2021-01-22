        static void Main(string[] args)
        {
            A classA = new A();
            B classB = new B();
            DoFunctionInClass(classA);
            DoFunctionInClass(classB);
            DoFunctionInClass(classA as BaseClass);
            Console.ReadKey();
        }
        public static void DoFunctionInClass(BaseClass c) 
        {
            c.MyMethod();
        }
    public abstract class BaseClass
    {
        public abstract void MyMethod();
    }
    public class A : BaseClass
    {
        public override void MyMethod()
        {
            Console.WriteLine("Class A");
        }
    }
    public class B : BaseClass
    {
        public override void MyMethod()
        {
            Console.WriteLine("Class B");
        }
    }
