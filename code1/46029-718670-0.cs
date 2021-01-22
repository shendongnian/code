    public class ClassA
    {
        protected static int num = 5;
    
        public static int GetNum()
        {
            return num;
        }
    }
    
    public class ClassB : ClassA
    {
        static ClassB()
        {
            num = 6;
        }
    }
