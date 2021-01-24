    static void Main(string[] args)
    {
        var isOk = false;
        var listOfNumbersNum = new List<int>();
        while (!isOk)
        {
            Console.WriteLine("Enter a number, or ok to finish");
            var text = Console.ReadLine();
            var isNumber = int.TryParse(text, out var numberNum);
            if (isNumber)
            {
                listOfNumbersNum.Add(numberNum);
            }
            else
            {
                if (text != null && text.Equals("ok", StringComparison.OrdinalIgnoreCase))
                {
                    var sumOfNumbers = listOfNumbersNum.Sum();
                    Console.WriteLine("Result of sum: " + sumOfNumbers);
                    isOk = true;
                }
            }
        }
        Console.WriteLine("Press any key to exit");
        Console.ReadLine();
    }
