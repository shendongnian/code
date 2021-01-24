    static public int AskInt(string question)
    {
        for (;;)
        {
            Console.Write(question);
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
        }
    }
