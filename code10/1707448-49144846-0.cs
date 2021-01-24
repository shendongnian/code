    public class ClassA
    {
        static ClassA singleton = null;
        public static ClassA GetInstance()
        {
            if (singleton == null)
                singleton = new ClassA();
            return singleton;
        }
        public void CallMe()
        {
        }
    }
    public class ClassB
    {
       public void WannaCallYou()
       {
           ClassA.GetInstance().callMe();
       }
    }
