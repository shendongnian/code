    int upperBound = 255, lowerBound = 1;
    List<int> range = new List<int>();
    while(lowerBound <= upperBound)
    {
     range.Add(lowerBound);
     lowerBound++;
    }
    List<string> existingNames = new List<string>() { "Name1", "Name2", "Name3", "Name10" };
    var availableNameList = range
                           .Except
                            ( 
                             existingNames
                             .Select(x => Int32.Parse(Regex.Match(x, @"\d+").Value))
                            )
                            .OrderBy(x=>x)
                            .Select(x=>"Name"+x)
                            .ToList();
