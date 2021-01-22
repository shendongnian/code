    class Class0
    {
        public int Test()
        {
            return 0;
        }
    }
    class Class1 : Class0
    {
        public new int Test()
        {
            return 1;
        }
    }
    . . .
    // result of 1
    Console.WriteLine(new Class1().Test());
