    string input = "QuoteNo:32586/CustomerNo:ABCDEF/TotalAmount:32/Processed:No";
    var query = from pair in input.Split('/')
                let items = pair.Split(':')
                select new
                {
                    Part = items[0],
                    Value = items[1]
                };
     // turn into list and access by index 
    var list = query.ToList();
    // or turn into dictionary and access by key
    Dictionary<string, string> dictionary 
        = query.ToDictionary(item => item.Part, item => item.Value);
