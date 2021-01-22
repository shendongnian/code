    string input = @"Verse 1 lyrics line 1
    Verse 1 lyrics line 2
    Verse 1 lyrics line 3
    Verse 1 lyrics line 4
    Verse 1 lyrics line 5
    
    Verse 2 lyrics line 1
    Verse 2 lyrics line 2
    Verse 2 lyrics line 3
    Verse 2 lyrics line 4
    Verse 2 lyrics line 5
    
    Verse 3 lyrics line 1
    Verse 3 lyrics line 2
    Verse 3 lyrics line 3
    Verse 3 lyrics line 4
    Verse 3 lyrics line 5
    ";
    
    // commented original Regex.Split approach
    //var split = Regex.Split(input, Environment.NewLine);
    var split = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    // find first blank line to determine # of verses
    int index = Array.FindIndex(split, s => s == "");
    var result = split.Where(s => s != "")
                      .Select((s, i) => new { Value = s, Index = i })
                      .GroupBy(item => item.Index % index);
    
    foreach (var group in result)
    {
        foreach (var item in group)
        {
            Console.WriteLine(item.Value);
        }        
        Console.WriteLine();
    }
