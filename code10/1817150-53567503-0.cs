    while (true)
    {                                                                                         
        Console.Write("Welcome. Do you want to tell us your name? (y/n): ");
        answer = Console.ReadLine();
        if (answer == "y") 
        {
            Console.Write("What is your name: ");
            userName = Console.ReadLine();  
            Console.WriteLine("Welcome, {0}", userName);
            break; // <-- exit the loop
        }
        if (answer == "n")
        {
            Console.WriteLine("Acknowledged.");
            break;  //<-- exit the loop
        }
        Console.WriteLine("Sorry, I didn't catch that."); }
    } 
