    var ss = objdb.Table1.Where(x => x.Table1Id >= 0).ToList();
    var tblList = ss.Select(x => new
    {
    tbl2 = objdb.Table2
      .Where(z => z.Table1Id == x.Table1Id)
       .Select(s => new
              {
               code= s.code,
               name= s.name,
               place= z.place
              }).ToList()
    }).ToList();
