    static public bool askBool(string question)
    {
        Console.Write(question);
        var input = Console.ReadLine();
        if (input == "y")
        {
            return true;
        }
        else if(input == "n")
        {
            return false;
        }
        else//It's not y or n: throw the exception.
        {
            throw new FormatException("Only y or n Allowed");
        }
    }
