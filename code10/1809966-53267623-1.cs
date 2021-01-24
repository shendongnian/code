    List<IEnumerable<string>> allLists = new List<IEnumerable<string>>();
                allLists.Add(report[0]);
                allLists.Add(report[1]);
                allLists.Add(report[2]);
    
                var result = allLists.SelectMany(l => l.Select(x => new
                {
                    Log = x,
                    Time = TimeSpan.Parse(x.Split(' ')[0])
                })).OrderBy(x => x.Time)
                .ToList();
