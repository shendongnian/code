        string which = Console.ReadLine();
        if (which == "s")
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Savingacc savingAccountObj;
            savingAccountObj = new Savingacc();
            savingAccountObj.mainmenu();                
        }
        else if (which == "c")
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Currentacc curAccountObj;
            curAccountObj = new Currentacc();
            curAccountObj.mainmenu();
        }
