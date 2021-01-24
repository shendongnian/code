    //include licenses in the user entity
    var result = ctx.User.Include(x=>x.Licenses).Where(t=>t.Id == _id).FirstOrDefault()
    //get the licenses you are looking for, either equal or use .Contains
    var licensesOfUser = result.Where(x=>x.Licenses.Where(l=>l.id == _licenseId);
    //remove them from entity and save.
    result.Licenses.RemoveRange(licenseOfUser);
    ctx.SaveChanges();
