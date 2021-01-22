    List<string> months = new List<string>();
    List<int> years = new List<int>();
    
    dates.Select(d => d.Split('-'))
        .ToList()
        .ForEach(ss => {
                           months.Add(ss[0].Trim()); 
                           years.Add(2000 + int.Parse(ss[1].Trim()));
                       });
