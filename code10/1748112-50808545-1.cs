       while(!int.TryParse(menuChoice, out menuNumber) ||( menuNumber > 3 || menuNumber < 1))
         {                
             AlertMessage("You have enetered an invalid Number, please select a correct option! (1-3)", ConsoleColor.Red);
                menuChoice = Console.ReadLine();     
        }
