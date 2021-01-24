    var q = A_Col.AsQueryable().Where(a => !a.Locked)
    .Join(
       AB_Col.AsQueryable(),
       a => a.Id, 
       ab => ab.AId,
       (a, ab) => new
       {
          A = new { Id = a.Id, Name = a.Name, LastName = a.LastName }, // change here
          AB = new { AId = ab.AId, BId = ab.BId } // change here
       })
    .Join(
       B_Col.AsQueryable(), 
       a_doc => a_doc.AB.BId,
       b => b.Id, 
       (a, b) => new { Id = a.A.Id, Name = a.A.Name, LastName = a.A.LastName, B = new { Name = b.Name, Id = b.Id } }) // change here
    .GroupBy(doc => new { Id = doc.Id, Name = doc.Name, LastName = doc.LastName }) // change here
    .Join(
        AC_Col.AsQueryable(),
        g => g.Key.Id,
        ac => ac.AId,
        (g, ac) => new
        {
           Id = g.Key.Id, // change here
           Name = g.Key.Name, // change here
           LastName = g.Key.LastName, // change here
           Bs = g.Select(x => x.B),
           AC = new { ac.AId, ac.CId }
        })
    .Join(
        C_Col.AsQueryable(),
        gac => gac.AC.CId,
        c => c.Id,
        (gac, c) => new { Id = gac.Id, Name = gac.Name, LastName = gac.LastName, Bs = gac.Bs, C = new { Name = c.Name, Id = c.Id } }) // change here
    .GroupBy(doc => new { Id = doc.Id, Name = doc.Name, LastName = doc.LastName, Bs = doc.Bs }) // change here
    .Select(g => new { Id = g.Key.Id, Name = g.Key.Name, LastName = g.Key.LastName, Bs = g.Key.Bs, Cs = g.Select(x => x.C) }); // change here
