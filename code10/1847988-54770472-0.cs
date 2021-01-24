    class Program
    {
        static void Main(string[] args)
        {
            var s = new SOmeClass();
            s.SomeMethod1();
            s.SomeMethod2();
        }
    }
    public class Base
    {
        protected  void ThisWillBeCalledBeforeAnyMethodInChild()
        {
            Console.WriteLine("ThisBefore");
        }
        protected  void ThisWillBeCalledAFTERAnyMethodInChild()
        {
            Console.WriteLine("ThisAFTER");
        }
    }
    public class SOmeClass : Base
    {
        public  void SomeMethod1()
        {
            base.ThisWillBeCalledBeforeAnyMethodInChild();
            Console.WriteLine("SomeMethod1");
        }
        public  void SomeMethod2()
        {
            Console.WriteLine("SomeMethod2");
            base.ThisWillBeCalledAFTERAnyMethodInChild();
        }
    }
