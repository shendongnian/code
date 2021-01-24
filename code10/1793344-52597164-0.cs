    int sum = 0;
    while (true)
    {
       string inputData = Console.ReadLine();
       if (inputData.Equals("x", StringComparison.OrdinalIgnoreCase))
       {
           break;
       }
       int input = 0;
       if (Int32.TryParse(inputData, out input))
       {
         sum += input;
       }
    }
    Console.WriteLine("Total sum is : " + sum);
    Console.ReadLine();
