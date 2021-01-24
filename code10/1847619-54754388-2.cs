    var p = new List<Candidate> 
    { 
    	new Candidate { Name = "John", Hash = "1" }, 
    	new Candidate { Name = "Mike", Hash = "2" } 
    };
    
    var n = new List<Candidate> 
    { 
    	new Candidate { Name = "Mike", Hash = "1" }, 
    	new Candidate { Name = "John", Hash = "2" } 
    };
       
    var joined = p.Concat(n).GroupBy(item => item.Hash);
    
    Console.WriteLine(string.Join("\n", joined
        .Where(g => g.Count() == 2)
        .Select(g => $"Old name {g.First().Name}, New name {g.Last().Name}")));
    // Old name John, new name Mike
    // Old name Mike, new name John
