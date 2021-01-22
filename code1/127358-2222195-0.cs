    var q = from cp in Context.ContentPages
            where cp.ID == someId
            select new 
            {
                ID = cp.ID,
                Name = cp.Name,
                ContentPageZones = from cpz in cp.ContentPageZones
                                   where cpz.Content.IsActive
                                   select new 
                                   {
                                       ID = cpz.ID,
                                       // etc.
                                   }
            };
