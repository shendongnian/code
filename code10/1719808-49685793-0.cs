    clientList= db.Clients
         .Where(ab => ab.Id==1)
         .Select(ab => new NewModel 
          {
             ClientName= ab.ClientName,  
             FacebookLinks= ab.ClientSocials.Select(cs => cs.FB_LINK).ToList()
          }).Single();
