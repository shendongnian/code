    var result = list.GroupBy(
                     x => new
                        {
                           x.Name,
                           x.SourceDeviceId
                        })
                 .Select(
                     x => new
                        {
                           x.Key.Name,
                           x.Key.SourceDeviceId
                        })
                 .ToList();
