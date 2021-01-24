    List<AR> SE = Prof(id);
    List<AG> TE = SE.Select(s =>
        new AG
        {
            // set inv property
            inv = s.inv,
            // dE is an array of ClassD instances, 
            //so to get some single ClassA instance for setting AD property you can do:
            // AD = s.dE.Single().AD
            //or
            // AD = s.dE.FirstOrDefault()?.AD
        }).ToList();
