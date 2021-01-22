    class Class0
    {
        protected int Test()
        {
            return 0;
        }
    }
    class Class1 : Class0
    {
        // same access modifier
        protected new int Test()
        {
            return 1;
        }
    }
    class Class2 : Class1
    {
        public int Result()
        {
            return Test();
        }
    }
    . . .
    // result of 1
    Console.WriteLine(new Class2().Result());
