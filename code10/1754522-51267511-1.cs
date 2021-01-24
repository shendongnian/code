    string csv = @"Id, Name, City
        1, Tom, NY
        2, Mark, NJ
        3, Lou, FL
        4, Smith, PA
        5, Raj, DC";
    // Read all lines
    var lines[] = File.ReadAllLines(csv);
    
    XElement xml = new XElement("Deltagere",
               // get second column of second line : Tom
               new XElement("NodeName", lines[1].Split(",").GetValue(1)),
               // get third column of fourth line : FL
               new XElement("NodeName2", lines[3].Split(",").GetValue(2))
    );
