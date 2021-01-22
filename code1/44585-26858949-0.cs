    class Example {
        public int varOne;
        public int varTwo;
        public void getValues()
        {
            Console.WriteLine("varOne : " + varOne + ", varTwo : " + varTwo);
        }
    }
    static void Main(string[] args)
        {
            Example e = new Example{ varOne = 42, varTwo = 256};
            e.getValues();
        }
