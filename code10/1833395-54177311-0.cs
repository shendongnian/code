    private static double GetDoubleFromUser(string prompt = null)
    {
        double result;
        do
        {
            Console.Write(prompt);
        } while (!double.TryParse(Console.ReadLine(), out result));
        return result;
    }
