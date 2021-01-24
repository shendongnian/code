    for (int maxNames = 0; maxNames < names.Length; maxNames++)
    {
       // Also, move your input WITHIN the loop
       userInput = Console.ReadLine(); // store the name in userInput
    
       if (userInput == "") // if the entry is null, stop taking names.
       {
          Console.WriteLine("You entered {0}", names);
          Console.ReadKey();
       }
       else if (userInput == "QUIT") // if the entry is QUIT, stop taking names.
       {
          Console.WriteLine("You entered {0}", names);
          Console.ReadKey();
       }
       else 
       // if it isn't null or QUIT, continue populating the array until we hit the max.
       {
          // since maxNames is now properly starting at 0,
          // you don't need your other name counter variable.
          // just use maxNames.  The loop process will increase it next cycle through
          names[maxNames] = userInput;
       }
    }
