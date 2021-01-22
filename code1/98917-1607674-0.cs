    var list = ...list of Persons...
    var areas = list.GroupBy( p => p.AreaID )
                    .Select( g => new {
                        AreaID = g.Key,
                        Count = g.Count()
                     });
