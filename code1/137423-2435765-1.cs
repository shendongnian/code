        public int SumThemAll(params int[] numbers)
        {
            return numbers.Sum();
        }
        public void SumThemAllAndPrintInString(string s, params int[] numbers)
        {
            Console.WriteLine(string.Format(s, SumThemAll(numbers)));
        }
        public void MyFunction()
        {
            int result = SumThemAll(2, 3, 4, 42);
            SumThemAllAndPrintInString("The result is: {0}", 1, 2, 3);
        }
