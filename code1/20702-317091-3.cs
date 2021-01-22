    foreach(row in result)
    {
       if (row.MasterId != currentMaster.MasterId)
       {
           list.Add(currentMaster);
           currentMaster = new Master { MasterId = row.MasterId, Name = row.Name };
       }
       currentMaster.Details.Add(new Detail { DetailId = row.DetailId, Amount = row.Amount});
    }
    list.Add(currentMaster);
