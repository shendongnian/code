    class Quote
    {
        static public Quote Calculate(int inputData)
        {
            var foo = DoComputations(inputData);
            return new Quote(foo);
        }
        public Quote(Foo foo)
        {
            //Initialize member variables based on the output of the calculations (a.k.a. foo)
        }
    }
