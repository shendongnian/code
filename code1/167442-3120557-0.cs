    from IO_Time in db.IO_Times
    join NameTable in db.NamesTable on IO_Time.IDNum equals NameTable.IDNum
    orderby SqlMethods.DateDiffMinute(IO_Time.TimeIn, IO_Time.TimeOut) descending
    group IO_Time by new { IO_Time.IDNum, NameTable.Name } into list
    select new
    {
      ID = list.Key.IDNum,
      Name = list.Key.Name
      Time = list.Max(t=> t.TimeOut-t.TimeIn)    
    });
