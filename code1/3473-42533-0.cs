    public class MyClass
    {
        private Object thisLock = new Object();
        private static readonly MyClass instance = new MyClass();
        public static MyClass Instance
        {
            get { return instance; }
        }
        private Int32 value = 0;
        public Int32 Toggle()
        {
            lock(thisLock)
            {
                if(value == 0) 
                {
                    value = 1; 
                }
                else if(value == 1) 
                { 
                    value = 0; 
                }
                return value;
            }
        }
    }
