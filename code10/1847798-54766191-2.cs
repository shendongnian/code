     var q = from a in A_Col.AsQueryable()
         where !a.Locked
         join ab in AB_Col.AsQueryable() on a.Id equals ab.AId into j1
         from abi in j1.DefaultIfEmpty()
         select new {A = new {a.Id, a.Name, a.LastName }, abi.BId } into r1
         join b in B_Col.AsQueryable() on r1.BId equals b.Id into r2
         from bi in r2.DefaultIfEmpty()
         select new { r1.A, B = new { bi.Id, bi.Name } } into r2
         group r2 by r2.A into g1
         select new { A = g1.Key, Bs = g1.Select(i => new { Id = i.B.Id ?? "", Name = i.B.Name ?? ""  }) } into r3
         join ac in AC_Col.AsQueryable() on r3.A.Id equals ac.AId into j2
         from aci in j2.DefaultIfEmpty()
         select new { r3.A, r3.Bs, aci.CId } into r4
         join c in C_Col.AsQueryable() on r4.CId equals c.Id into j2
         from ci in j2.DefaultIfEmpty()
         select new { r4.A, r4.Bs, C = new { ci.Id, ci.Name } } into r5
         group r5 by new {r5.A, r5.Bs} into g2
         select new { g2.Key.A, g2.Key.Bs, Cs = g2.Select(i => new { Id = i.C.Id ?? "", Name = i.C.Name ?? ""  }) };
