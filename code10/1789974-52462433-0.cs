     var dist = dbCollection.Aggregate().Group(d => d.Name, o =>
                new
                {   
                    Name = o.Key,
                    Data = o.Select(_ => _.Symbol).Distinct(),
                }).ToEnumerable();
    
                dist.ToList().ForEach(_ =>
                    {
                        _.Data.ToList().ForEach(d => Console.WriteLine("Company: " +_.Name + " Symbol: " + d));
                    }
                );
