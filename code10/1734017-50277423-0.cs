    var sysExist = db.Systems.FirstOrDefault(s => s.Name == name && s.OrganizationID == 4);
    
    if (sysExist  == null)
    {
       sysExist = new Systems()
       {
         Name = name,
         OrganizationID = 4,
         Online = true,
         SerialNumber = "1zz34343" 
       };
    
       db.Systems.Add(sysExist);
       db.SaveChanges();
    }
    // now sysExist contains old or new record
