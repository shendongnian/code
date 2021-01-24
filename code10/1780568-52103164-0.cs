    static void Main(string[] args)
            {
                int hour = 0, minute = 0;
                const int MAX_NUMBER_OF_DIGITS = 2 ;
    
                Console.Write("Enter Time (HH:MM) = ");
                
                int cursorLeft = Console.CursorLeft;
                int cursorTop = Console.CursorTop;
                
                // use ReadLine, else you will only get 1 character 
                // i.e. number more than 1 digits will not work
                hour = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(cursorLeft + MAX_NUMBER_OF_DIGITS , cursorTop);
    
                Console.Write(":");
    
                minute = int.Parse(Console.ReadLine());
    
                // Nitpickers! purposefully not using String.Format, 
                // or $, since want to keep it simple!
                Console.Write("You entered: " + hour + ":" + minute);
            }
