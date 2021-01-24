        Random rnd = new Random();
        int jk;  
        string option;
        if (Age >= 16)
        {
            Console.WriteLine("Do you want to hear a joke?"); 
            option = Console.ReadLine();
            while (option == "yes")
            {
                jk = rnd.Next(lower, upper + 1);    
                Console.WriteLine(jokes[jk]);
                Console.Read();
                Console.WriteLine("Do you want to hear a joke?"); 
                option = Console.ReadLine();
            } 
            Console.WriteLine("Have a nice day, " + Name);
            Console.Read();
        }
        else
        {
            Console.WriteLine("What a pitty! You're too young to hear this joke!");
            Console.Read();
            Console.WriteLine("Have a nice day, " + Age);
        }
