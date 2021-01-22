    public MyClass
    {
        private static Int32 counter = 0;
        public static MyClass GetAnInstance()
        {
            lock(MyClass)
            {
               counter++;
               return new MyClass();
            }
        }
        private Int32 myCount;
        private MyClass()
        {
            myCount = counter;
        }
    }
