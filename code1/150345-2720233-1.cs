    var pairs = File.ReadAllLines("filename.txt")
        .ToDictionary(line => line.Split(':')[0].Trim())
        .ToList();
    foreach (var pair in pairs)
    {
        pair.Value = pair.Value.Split(':')[1].Trim(); 
    }
