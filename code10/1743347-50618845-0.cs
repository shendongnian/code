    static public bool askBool(string question)
    {  
        while(true)
        {
            Console.Clear();
            Console.Write(question);
            var input = Console.ReadLine().ToLowerInvariant();
            switch (input)
            {
                case "y":
                case "yes": return true;
                case "n":
                case "no": return false;
            }
        }
    }
