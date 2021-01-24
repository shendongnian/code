    int counter = 0;
    string line;
    string price;
    var regex = new Regex("Price: £(?<amount>.*)");
    // Read the file and display it line by line.  
    using (System.IO.StreamReader file = new System.IO.StreamReader(@"c:Pricelist.txt"))
    {
      while ((line = file.ReadLine()) != null)
      {
        var match = regex.Match(line);
        if (match.Success)
        {
          price = match.Groups["amount"].Value;
          System.Console.WriteLine(price);
        }
        //System.Console.WriteLine(line);
        counter++;
      }
    }
    System.Console.WriteLine("There were {0} lines.", counter);
    // Suspend the screen.  
    System.Console.ReadLine();
