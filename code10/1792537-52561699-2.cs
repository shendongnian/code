    static void Main(string[] args)
    {
        bool isOk = new bool();
        var listOfNumbers = new List<string>();
        string text;
        int numberNum;
        var listOfNumbersNum = new List<int>();
        while (!isOk)
        {
            Console.WriteLine("Enter a number, or ok to finish");
            text = Console.ReadLine();
            bool isNumber = Int32.TryParse(text, out numberNum);
            if (isNumber)
            {
                listOfNumbersNum.Add(numberNum);
            }
            else
            {
                if (text.Equals("ok", StringComparison.OrdinalIgnoreCase))
                {
                    int sumOfNumbers = listOfNumbersNum.Sum();
                    Console.WriteLine(sumOfNumbers);
                    isOk = true;
                }
            }
        }
    }
