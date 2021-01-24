    collection.AsQueryable()
      .Select(p => new
        {
          tags = p.Tags.Count(),
          sensors = p.Tags.Select(x => x.Sensors.Count()).Sum()
        }
      );
