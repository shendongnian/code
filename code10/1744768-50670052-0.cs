    string str = "Hello World";
    
    var result = str.GroupBy(c => c)
                    .Select(group => new { Letter = group.Key, Count = group.Count() })
                    .OrderByDescending(x=>x.Count)
                    .First();
    char letter = result.Letter;
    int count = result.Count; 
