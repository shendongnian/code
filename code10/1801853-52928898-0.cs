    static void Main(string[] args)
    {
        var numbers = new int?[5];
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Please enter number {i+1}.");
            do
            {
                int n;
                while (!int.TryParse(Console.ReadLine(), out n))
                    Console.WriteLine("Invalid number. Please try again.");
                var currentNumber = Convert.ToInt32(n);
                var containsNumber = numbers.Contains(currentNumber);
                if (!containsNumber)
                {
                    numbers[i] = currentNumber;
                    break;
                }
                Console.WriteLine("Number was entered previously, please enter a different number.");
            } while (true);
            
        }
        Console.Clear();
        Array.Sort(numbers);
        foreach (int? n in numbers)
            Console.WriteLine(n);
        Console.ReadLine();
    }
