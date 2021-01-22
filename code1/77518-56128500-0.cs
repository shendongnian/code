    return (from a in dataContext.TableOfA
           where a.name == "Test" &&
           DbFunctions.AddHours(DbFunctions.CreateDateTime(
     a.Exp.Value.Year,a.Exp.Value.Month,a.Exp.Value.Day,a.Exp.Value.Hour,a.Exp.Value.Minute,
    a.Exp.Value.Millisecond),Someint) >=     
    DbFunctions.CreateDateTimeOffset(dt.Year,dt.Month,dt.Day,dt.Hour,dt.Minute,dt.Millisecond,0)
           select a).First();
