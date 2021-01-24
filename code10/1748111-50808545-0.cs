    while(!int.TryParse(menuChoice, out menuNumber))
            {                
             AlertMessage("You have enetered an invalid Number, please select a correct option! (1-3)", ConsoleColor.Red);           
                menuChoice = Console.ReadLine();     
        }
