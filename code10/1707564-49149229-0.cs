    int sel;
    char letter;
    bool valid = false;
    
    do
    {
        Console.WriteLine("Calculator");
        Console.WriteLine("********************");
        Console.WriteLine("1- Calculator");
        Console.WriteLine("2- Exit Calculator");
        Console.Write("Please enter your option here:  ");
    
        sel = int.Parse(Console.ReadLine());
    
        switch (sel)
        {
            case 1:
                SecondMenu();
                break;
    
            case 2:
                Environment.Exit(0); 
                break;
    
            default:
                Console.WriteLine("Sorry that is not correct format! Please restart!");     
                break;
        }
    }
    while (valid != true);
