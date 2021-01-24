    class FindMax
    {
        protected int Result; // Not private, because Number (inherits from FindMax) should access it.
        public int setMax(int numOne, int numTwo)
        {
            if (numOne >= numTwo)
                Result = numOne;
            else
                Result = numTwo;
            return Result;
        }
    }
    class Number : FindMax
    {
        public void getMax()
        {
            Console.WriteLine(Result);
        }
    }
