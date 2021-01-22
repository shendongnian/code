    DateTime dateTime = DateTime.Now.Subtract(new TimeSpan(0, 0, 10, 0));
    var result1 = from a in cpuInfo
                      where a.DateTime <= dateTime
                      select a;
    
    if (result1.Any())
    {            
        foreach (TblCPUInfo record1 in result1)
        {
                localDB.TblCPUInfo.DeleteOnSubmit(record1);
                localDB.SubmitChanges();
        }
    }
