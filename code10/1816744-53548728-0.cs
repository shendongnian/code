    for (int i = 0; i < nummer.Length; i++)
    {
        bool isAnInteger = false;
        int element = 0;
        Console.Write("Nummer " + talnr + ": ");
        talnr++;
        string str = Console.ReadLine();
        
        // evaluates to true if str can be parsed as an int, false otherwise
        // and outputs the parsed int to element
        isAnInteger = int.TryParse(str, out element); 
        while (!isAnInteger)
        {
            Console.Write("Wrong input, try again. ");
            str = Console.ReadLine();
            isAnInteger = int.TryParse(str, out element);
        }
        
        nummer[i] = element;
    
    }
