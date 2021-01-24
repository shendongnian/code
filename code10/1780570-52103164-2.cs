    static void Main(string[] args)
    {
        int hour = 0, minute = 0;
    
        Console.Write("Enter Time in format HH:MM = ");
    
        string enteredNumber = Console.ReadLine();
    
        string[] aryNumbers = enteredNumber.Split(':');
    
        if (aryNumbers.Length != 2)
        {
            Console.Write("Invalid time entered!");
        }
        else
        {
            hour = int.Parse(aryNumbers[0]);
            minute = int.Parse(aryNumbers[1]);
    
            // Nitpickers! purposefully not using String.Format, 
            // or $, since want to keep it simple!
            Console.Write("You entered: " + hour + ":" + minute);
    
        }
    }
