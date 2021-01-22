    .
    .
    .
    db.Detach(a);
    var pics = db.Picture.Where(p => p.Area.id == a.id).AsEnumerable()
                         .Select(p => new Picture() 
               {IsProfile = p.IsProfile, id = p.id, Path = p.Path, Title = p.Title});
    if (pics.Count()>0)
        foreach (var pic in pics)
           a.Pictures.Add(pic);
    
    return a;
