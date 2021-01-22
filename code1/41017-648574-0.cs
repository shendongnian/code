    static int ReadKey()
    {
        while (true)
        {
            char ch = Console.ReadKey().KeyChar;
            int result;
            if (int.TryParse(ch.toString(), out result))
            {
                return result;
            }
        }
    }
    
