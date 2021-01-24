    var license = db.Licenses.Where(l => l.ID == LicenseId).FirstOrDefault();
    var users = license.Users.ToList();
    if (users != null)
    {
        foreach (var user in users)
        {
             license.Users.Remove(user);
        }                   
    }
