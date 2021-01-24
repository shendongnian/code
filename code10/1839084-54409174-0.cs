    const string comma = ",";
    static void Main(string[] args)
    {
        int start = getNumber();
        int end = getNumber();
        if(start > end)
        {
            int placeHolder = end;
            end = start;
            start = placeHolder;
        }
        string delimiter = string.Empty;
        for(int i = start; i < end; i++)
        {
            if(i % 2 == 1)
            {
                Console.Write(string.Concat(delimiter,i.ToString()));
                delimiter = comma;
            }
        }
        Console.ReadLine();//otherwise you wont see the result
    }
    static int getNumber()
    {
        Console.Write("Please enter a number:");
        string placeHolder = Console.ReadLine();
        int toReturn = -1;
        if (int.TryParse(placeHolder, out toReturn))
            return toReturn;
        return getNumber();
    }
