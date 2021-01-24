    ...
    LatitudePosted = model.LatitudePosted,
    LongitudePosted = model.LongitudePosted,
    LocationPosted = model.LocationPosted,
    Published = true
    errand.Picture = imageBytes;
    
    ERRANDOM.Entry(errand).State = EntityState.Modified;
    
    if (imageBytes.Length <= 2)
    {
    	ERRANDOM.Entry(errand).Property(e => e.Picture).IsModified = false;
    }
    
    ERRANDOM.SaveChanges();
