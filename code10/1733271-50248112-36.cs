        var results = collection.AsQueryable()
          .SelectMany(p => p.Tags, (p, tag) => new
            {
              EndpointId = p.EndpointId,
              Uid = tag.Uid,
              Sensors = tag.Sensors
            }
          )
          .SelectMany(p => p.Sensors, (p, sensor) => new
            {
              EndpointId = p.EndpointId,
              Uid = p.Uid,
              Type = sensor.Type
            }
          )
          .GroupBy(p => new { EndpointId = p.EndpointId, Uid = p.Uid, Type = p.Type })
          .GroupBy(p => new { EndpointId = p.Key.EndpointId, Uid = p.Key.Uid },
            (k, s) => new { Key = k, count = s.Count() }
          )
          .GroupBy(p => p.Key.EndpointId,
            (k, s) => new
            {
              EndpointId = k,
              tagCount = s.Count(),
              sensorCount = s.Sum(x => x.count)
            }
          );
