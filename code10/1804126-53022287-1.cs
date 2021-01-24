    List<string> keys = new List<string>();
    keys.Add("Car");
    keys.Add("Card Payment");
    
    string description = "Card payment to tesco";
    
    var category = keys
    		.Where(p => description.ToLowerInvariant().Contains(p.ToLowerInvariant()))
    		.OrderByDescending(x => x.Length)
    		.Take(1)
    		.FirstOrDefault();
