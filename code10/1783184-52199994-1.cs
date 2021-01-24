    char[] allowedChars = new char[] { 'a', 'b'};   
    
    while(true){
        char inputChar = 'z';
        if (allowedChars.Length > 1)
        {
            Console.WriteLine(string.Format("Enter {0} or {1}:", string.Join(", ", allowedChars.Take(allowedChars.Length - 1)), allowedChars[allowedChars.Length - 1]));
        }
        else
        {
            Console.WriteLine(string.Format("Enter {0}", allowedChars[0]));
        }
        
        var result = char.TryParse(Console.ReadLine(), out inputChar);
    
        if (result && allowedChars.Contains(inputChar))
        {
            break;
        }
        else
        {
            Console.WriteLine("Try again");
        }
    }
    
    Console.WriteLine("Success");
    Console.ReadLine();
