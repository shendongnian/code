    abstract class Father
    {
        //Do you need it public?
        protected readonly int MyInt;
    }
    
    class Son : Father
    {
        public Son()
        {
            MyInt = 1;
        }
    }
