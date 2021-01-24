    static void Main(string[] args)
        {
            bool isOk = new bool();          
            bool isNumber = new bool();
    
            var listOfNumbers = new List<string>();
            var text = "0";
    
            int sumOfNumbers = new int();
            int numberNum = new int();
            var listOfNumbersNum = new List<int>();
    
            while (!isOk)
            {
                Console.WriteLine("Enter a number, or ok to finish");
                text = Console.ReadLine();
                bool isNumber= Int32.TryParse(text, out numberNum );
                if (isNumber)
                {
                    listOfNumbersNum.Add(numberNum);
                }
                else
                {
                    if (text.Equals("ok", StringComparison.OrdinalIgnoreCase))
                    {
                        sumOfNumbers = listOfNumbersNum.Sum();
                        Console.WriteLine(sumOfNumbers);
                        isOk = true;
                    }
    
                }
    
            }
        }
