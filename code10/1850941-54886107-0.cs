    searchTerm = searchTerm.ToLower();
    var result = allMachineData
        .Where(m => m.sessionList.Any(s => s.userId.ToLower().Contains(searchTerm) || s.userName.ToLower().Contains(searchTerm)))
        .Select(m => new Machine
        {
            collectionName = m.collectionName,
            machineName = m.machineName,
            status = m.status,
            sessionList = m.sessionList.Where(s => s.userId.ToLower().Contains(searchTerm) || s.userName.ToLower().Contains(searchTerm)).ToList(),
        }).ToList();
