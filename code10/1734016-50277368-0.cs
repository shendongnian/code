    var sys = db.Systems.FirstOrDefault(s => s.Name == name && 
    s.OrganizationID == 4);
    
    if (sys  == null)
    {
       sys = new Systems()
       {
         Name = name,
         OrganizationID = 4,
         Online = true,
         SerialNumber = "1zz34343" 
       };
    
       db.Systems.Add(sys);
       db.SaveChanges();
