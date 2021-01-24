    Boolean keepRunning = true;
    while (keepRunning = true)
    {
    	string input = Console.ReadLine();
    
        if (input == "1")
        {
            Console.WriteLine("Still running");
        }
        else if (input == "2")
        {
            Console.WriteLine("Still running2");
        }
        else if (input == "3")
        {
            Console.WriteLine("Still running3");
        }
        else if (input == "4")
        {
            Console.WriteLine("Still running4");
        }
        else if (input == "5")
        {
            Console.WriteLine("Still running5");
        }
        else if (input == "6")
        {
            keepRunning = false;
        }
    }
