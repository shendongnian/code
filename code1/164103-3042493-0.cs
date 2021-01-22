    string input = "QuoteNo:32586/CustomerNo:ABCDEF/TotalAmount:32/Processed:No";
    
    var query = from pair in input.Split('/')
                let items = pair.Split(':')
                select new
                {
                    Part = items[0],
                    Value = items[1]
                };
    
    foreach (var item in query)
    {
        Console.WriteLine("{0}\t{1}", item.Part, item.Value);
    }
