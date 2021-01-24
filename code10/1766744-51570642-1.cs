    var listMaster = new List<Master>();
    var listUpdate = new List<Update>();
    
    listMaster.Add(new Master { ID = 1, Name = "Jai" });
    listMaster.Add(new Master { ID = 2, Name = "Ram" });
    listMaster.Add(new Master { ID = 3, Name = "Amit" });
    listMaster.Add(new Master { ID = 4, Name = "Mohan" });
    listMaster.Add(new Master { ID = 5, Name = "JAg" });
    listUpdate.Add(new Update { ID = 1, Name = "JaiU" });
    listUpdate.Add(new Update { ID = 2, Name = "RamU" });
    listUpdate.Add(new Update { ID = 3, Name = "ShyamU" });
    
    listMaster.RemoveAll(c => !listUpdate.Any(x => x.ID == c.ID));
