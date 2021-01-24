     HashSet<int> hasCompletedA = new HashSet<int>();
     HashSet<int> hasCompletedB = new HashSet<int>();
     var query = File
       .ReadLines(@"c:\MyFile.csv")
       .Where(line => !string.IsNullOrWhiteSpace(line))
       .Select(line => YourParserHere(line));
     foreach (var record in query) {
       if (record.CompletedA != null)
         hasCompletedA.Add(record.Key);
       if (record.CompletedB != null)
         hasCompletedB.Add(record.Key);
     }
     // Keys which have both CompletedA and CompletedB 
     var bothAandB = hasCompletedA.Intersect(hasCompletedB); 
