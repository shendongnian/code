    var Table1 = context.Table1.ToList(); // materialize Table1
    var query = Table1.Select(x=> new{
       x.T1_Name,
       x.T1_Id,
       T2 =x.Table2.Select(y=> new { // Table2 not materialized, so do it now
          y.T2_Name,
          y.T2_Value
       })
    }).ToList();
