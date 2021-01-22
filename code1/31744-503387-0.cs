    static Int16 PromptForInt16(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            Int16 result;
            if (Int16.TryParse(Console.ReadLine(), out result))
            {
                return result;
            }
            Console.WriteLine("Sorry, invalid number entered. Try again.");
        }
    }
