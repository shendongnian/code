    private static bool GetInput(string msg, out int converted)
    {
        Console.Write(msg);
        bool result = false;
        converted = 0;
        do
        {
            Console.Write(msg);
            string str = Console.ReadLine();
            result = int.TryParse(str, out converted);
            if (result && converted < 1)
            {
                Console.WriteLine("Your number is out of range");
                result = false;
            }
            if (!result && string.IsNullOrEmpty(str))
            {
                Console.WriteLine("You must enter a value.");
            }
            if (!result && !string.IsNullOrEmpty(str))
            {
                Console.WriteLine("You must enter a valid number.");
            }
        } while (!result);
        return result;
    }
