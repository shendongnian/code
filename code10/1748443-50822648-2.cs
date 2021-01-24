    //include users in license entities  
    var result = ctx.License.Include(x=>x.Users).Where(t=>t.Id == _id).FirstOrDefault()
    //get the users you are looking for, either equal or use .Contains
    var usersOfLicenses = result.Where(x=>x.Users.Where(l=>l.id == _userId);
    //remove them from entity and save.
    result.Users.RemoveRange(licenseOfUser);
    ctx.SaveChanges();
