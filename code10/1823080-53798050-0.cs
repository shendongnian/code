        static void ExitGame()
    {
      Console.WriteLine("Does you want to play again");
      if (replay == "y")//; Remove this semicolon
      {
      Console.WriteLine("\nOkay, guess again");
      askData(EndProg == "No");
      }
      else if (replay == "n")//; Remove this semicolon
      {
        askData(EndProg == "Yes");
      }
      else
      {
        Console.ReadLine();
      }
    }
