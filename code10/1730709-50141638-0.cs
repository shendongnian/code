    BeginLoop:
        Console.WriteLine("Enter a number of dice to roll:");
        string numberDiceString = Console.ReadLine();
        if (numberDiceString == "quit")
        {
            goto EndLoop;
        }
        int numberDice = Convert.ToInt32(numberDiceString);
        /* Rest of code you want to do per iteration */
        goto BeginLoop;
    EndLoop:
      
