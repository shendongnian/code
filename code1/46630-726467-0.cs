        enum test
        {
            VAL1,
            VAL2
        }
        static void Main(string[] args)
        {
            test newTest = (test)Enum.Parse(typeof(test), "VAL2");
            Console.WriteLine(newTest.ToString());
        }
