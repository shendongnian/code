    var q = result.ToList();
    var tagIDs = new HashSet<int>() { 3, 4 };
    IEnumerable<string> itemContents = 
        q.Where(x => tagIDs.Contains(x.TagID)). // Keep only the tags we're interested in
          GroupBy(x => x.Id). // Group the items by ID
          Where(g => (g.Count() == tagIDs.Count)). // Select the groups having the right number of items
          SelectMany(g => g.Select(x => x.ItemContent)). // Extract ItemContent
          Distinct(); // Remove duplicates
    
