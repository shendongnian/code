     bool hasSepcialCharacters;
          Console.WriteLine("Please enter name: ");
          string name = Console.ReadLine();
          Regex RgxUrl = new Regex("[^a-z0-9A-Z]");
    
          hasSepcialCharacters = RgxUrl.IsMatch(name);
    
          if(hasSepcialCharacters)
            Console.WriteLine("Has special characters");
          else
          Console.WriteLine("No special characteres");
    
          Console.ReadLine();
