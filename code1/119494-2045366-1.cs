    int nextColor;
    input = Console.ReadLine();
    
    while( ! Int32.TryParse( input, out nextColor ) 
           || nextColor > numColors 
           || nextColor < 0 )
    { 
    	Console.WriteLine("Unrecognized input: " + input);
        Console.WriteLine("Please enter a value between 0 and " + numColors + ".");
    	input = Console.ReadLine();
    }
