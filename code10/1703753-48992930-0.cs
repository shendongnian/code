    var m1 = db.M1.Include(r => r.Qualité).Select(r => new {
        Column1Name = r.Column1Name,
        Column2Sub = r.Qualité.Column2Sub,
        ..etc
    });
    return View(m1.ToList());
