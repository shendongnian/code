    static public bool askBool(string question)
    {
        Console.Write(question);
        if (Console.ReadLine() == "y")
        {
            return true;
        }
        else if(Console.ReadLine() == "n")
        {
            return false;
        }
        else//It's not y or n: throw the exception.
        {
            throw new FormatException("Only y or n Allowed");
        }
    }
