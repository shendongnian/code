    String lineIn = Console.ReadLine();
    if (!String.IsNullOrEmpty(lineIn))
    {
        Int16 myNum;
        if (Int16.TryParse(lineIn , out myNum))
        {
                switch(myNum)
                {
                        case 1:
                        ...
                        default:
                        ...
                }
        }
    }
