    string[] configLines = File.ReadAllLines("a.txt");
    var dataLines = from line in File.ReadAllLines("b.txt")
                    let split = line.Split('|')
                    select new { Key = split[0], Value = split[1] };
    var lookup = dataLines.ToLookup(x => x.Key, x => x.Value);
    using (TextWriter writer = File.CreateText("result.txt"))
    {
        foreach (string key in configLines)
        {
            writer.WriteLine("{0}|{1}",
                key, string.Join("|", dataLines[key].ToArray()));
        }
    }
    
