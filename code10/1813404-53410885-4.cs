    var results = 
        session
            .Query<Role>()
            .Fetch(r => r.Attributes)
            .ToList();
    var json = 
        JsonConvert.SerializeObject(
           results
               .Select(r => 
                   new 
                   {
                       r.Id,
                       r.Name,
                       allowedAttributes = r.Attributes
                   });
