    private static int GetNumberFromUser(string prompt)
    {
        int result;
        do
        {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out result));
        return result;
    }
    private static int AddNumbers(int first, int second)
    {
        return first + second;
    }
