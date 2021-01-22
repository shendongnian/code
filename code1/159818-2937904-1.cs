    // Load data.
    string[][] data = new string[][] {
        new string[] { "kumar", "fes", "All" },
        // etc.
    };
    
    ICollection<Information> infoData = data.Select(new Information(data)); // or however you load data.
    
    // Find children of each node.
    foreach(var info in infoData) {
        info.Children = infoData.Where(other => other.Name == info.Parent).ToList();
    }
    var rootChildren = infoData.Where(other => other.Name == "All");
    
