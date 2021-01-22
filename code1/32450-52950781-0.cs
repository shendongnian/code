    public static class Runnable
    {
        public static void Run()
        {
            MyClass myClass = MyClassPrivilegeKey.MyClassFactory.GetInstance();
        }
    }
    
    public abstract class MyClass
    {
        public MyClass(MyClassPrivilegeKey key) { }
    }
    
    public class MyClassA : MyClass
    {
        public MyClassA(MyClassPrivilegeKey key) : base(key) { }
    }
    
    public class MyClassB : MyClass
    {
        public MyClassB(MyClassPrivilegeKey key) : base(key) { }
    }
    
    
    public class MyClassPrivilegeKey
    {
        private MyClassPrivilegeKey()
        {
        }
    
        public static class MyClassFactory
        {
            private static MyClassPrivilegeKey key = new MyClassPrivilegeKey();
    
            public static MyClass GetInstance()
            {
                if (/* some things == */true)
                {
                    return new MyClassA(key);
                }
                else
                {
                    return new MyClassB(key);
                }
            }
        }
    }
