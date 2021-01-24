    var lines = File.ReadAllLines(@"C:\example2.csv");   
    var line = File.ReadAllLines(@"C:\example1.csv");
        
    var linesToWrite = new List<string>();    
    
    foreach (var s in lines)
    {
        var split = s.Split(',');
        if (split.Intersect(line).Any())
        {
            linesToWrite.Remove(s);
        }
    
    }
    
    File.WriteAllLines("file3.csv", linesToWrite);
