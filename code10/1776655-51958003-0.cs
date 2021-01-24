    private static int GetIntFromUser(string prompt, int minValue = int.MinValue, 
        int maxValue = int.MaxValue)
    {           
        int result;
        string errorMsg = $"ERROR: Input must be a valid number from {minValue} to {maxValue}";
            
        while(true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (!int.TryParse(input, out result) || result < minValue || result > maxValue)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMsg);
                Console.ResetColor();
            }
            else
            {
                break;
            }
        }
        return result;
    }
