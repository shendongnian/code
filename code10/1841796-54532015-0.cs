    ctx
    .Object
    .Include("Users")
    .Include("Countries")
    .Select(rec => new ObjectDTO {
       ID = rec.ID,
       Name = rec.Name,
       StatusID = rec.StatusID,
       UserIDs = rec.Users.Select(usr => usr.ID).ToArray(),
       CountryIDs = rec.Countries.Select(cnt => cnt.ID).ToArray()
    });
