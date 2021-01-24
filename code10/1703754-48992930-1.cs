    var m1 = db.M1.Include(r => r.M2).Include(r => r.Qualité).Select(r => new {
        Poids = r.M2.Sum(x => x.Poids),
        Col1 = r.Col1,
        Col2 = r.Col2,
        Col3 = r.Col3,
        Col4 = r.Col4
    });
    return View(m1.ToList());
