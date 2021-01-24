    IQueryable<Kisi> query = db.Kisi.Where(item => item.KAYITTIPI == registerType);
    if (!String.IsNullOrEmpty(name))
    {
       query = query.Where(item => item.ADI.Contains(name))
    }
    if (!String.IsNullOrEmpty(surname))
    {
        query = query.Where(item => item.SOYADI.Contains(surname))
    }
    var result = query.Where(item => item.UNVAN.Contains(title))
                      .OrderBy(item => item.ID)
                      .Skip(page)
                      .Take(top)
                      .ToList();
