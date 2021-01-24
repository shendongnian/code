    var q = A_Col.AsQueryable().Where(a => !a.Locked)
      .Join(
          AB_Col.AsQueryable(), a => a.Id, ab => ab.AId,
          (a, ab) => new { A = new { a.Id, a.Name, a.LastName }, ab.BId })
      .Join(
          B_Col.AsQueryable(),
          a_doc => a_doc.BId,
          b => b.Id,
          (a, b) => new { a.A, B = new { b.Id, b.Name } })
      .GroupBy(doc => doc.A)
      .Select(g => new { A = g.Key, Bs = g.Select(i => i.B)}) // <----- THIS ONE HERE!!
      .Join(
          AC_Col.AsQueryable(),
          r => r.A.Id,
          ac => ac.AId,
          (r, ac) => new { r.A, r.Bs, ac.CId })
      .Join(
          C_Col.AsQueryable(),
          gac => gac.CId,
          c => c.Id,
          (gac, c) => new { gac.A, gac.Bs, C = new { c.Name, c.Id } })
      .GroupBy(doc => new { doc.A, doc.Bs })
      .Select(g => new { g.Key.A, g.Key.Bs, Cs = g.Select(i => i.C) });
