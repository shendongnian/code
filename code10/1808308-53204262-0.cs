    var computers = db.Computers.Where(x => workStations.Any(y => y.Equals(x.Id)).ToList();
    
    foreach (var computer in computers)
    {
        if (!dict.ContainsKey(computer.Id))
        {
            dict.Add(computer.Id, computer);
        }
    }
