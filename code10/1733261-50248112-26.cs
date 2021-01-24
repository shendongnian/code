    collection.AsQueryable()
      /* Use the Where if you want a query to match only those documents */
      //.Where(p => p.EndpointId == "89799bcc-e86f-4c8a-b340-8b5ed53caf83")            
      .GroupBy(p => p.EndpointId, (k,s) => new
        {
          tags = s.Sum(p => p.Tags.Count()),
          sensors = s.Sum(p => p.Tags.Select(x => x.Sensors.Count()).Sum())
        }
      );
