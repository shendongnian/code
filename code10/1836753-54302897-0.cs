    List<RFPModel> lst = new List<RFPModel>();
    lst.Add(new RFPModel { StatusID = 1 });
    lst.Add(new RFPModel { StatusID = 1 });
    lst.Add(new RFPModel { StatusID = 1 });
    lst.Add(new RFPModel { StatusID = 2 });
    lst.Add(new RFPModel { StatusID = 2 });
    lst.Add(new RFPModel { StatusID = 3 });
    lst.Add(new RFPModel { StatusID = 4 });
    lst.Add(new RFPModel { StatusID = 4 });
    lst.Add(new RFPModel { StatusID = 4 });
    lst.Add(new RFPModel { StatusID = 4 });
    lst.Add(new RFPModel { StatusID = 5 });
    var lookup = lst.ToLookup(p => p.StatusID);
    var status1Count = lookup[1].Count(); // 3
    var status2Count = lookup[2].Count(); // 2
    var status3Count = lookup[3].Count(); // 1
    var status4Count = lookup[4].Count(); // 4
    var status5Count = lookup[5].Count(); // 1
