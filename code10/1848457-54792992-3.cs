    var results = list
        .GroupBy(
            x => new Tuple<Guid, Guid>(x.SomeId1, x.SomeId2), 
            (x, y) => {
                return new MyDto {
                    SomeId1 = x.Item1,
                    SomeId2 = x.Item2,
                    JsonDictionary = y
                        .SelectMany(z => z.JsonDictionary)
                        .ToLookup(z => z.Key, z => z.Value)
                        .ToDictionary(z => z.Key, z => z.First())
                };
            });
