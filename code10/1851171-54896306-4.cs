    private static double GetDoubleFromUser(string prompt, Func<double, bool> validator = null)
    {
        double result;
        do
        {
            Console.Write(prompt);
        } while (!double.TryParse(Console.ReadLine(), out result) ||
                 (validator != null && !validator.Invoke(result)));
        return result;
    }
