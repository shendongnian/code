        static void Main()
        {
            IMyInterface ob1, obj2;
            ob1 = getIMyInterfaceObj();
            obj2 = getIMyInterfaceObj();
            Console.WriteLine(ob1.CallSomeMethod());
            Console.WriteLine(obj2.CallSomeMethod());
            Console.ReadLine();
        }
        private static bool isfirstTime = true;
        private static IMyInterface getIMyInterfaceObj()
        {
            if (isfirstTime)
            {
                isfirstTime = false;
                return new ImplementingClass1();
            }
            else
            {
                return new ImplementingClass2();
            }
        }
    }
    public class ImplementingClass1 : IMyInterface
    {
        public ImplementingClass1()
        {
        }
        #region IMyInterface Members
        public bool CallSomeMethod()
        {
            return true;
        }
        #endregion
    }
    public class ImplementingClass2 : IMyInterface
    {
        public ImplementingClass2()
        {
        }
        #region IMyInterface Members
        public bool CallSomeMethod()
        {
            return false;
        }
        #endregion
    }
    public interface IMyInterface
    {
        bool CallSomeMethod();
    }
