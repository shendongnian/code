    DbContext.MyLinkedEntities
        .GroupBy( mle => mle.MyEntity )
        .Select( g => new
        {
            Id = g.Key.Id,
            RuleCount = g.Where( s => s.MyBoolean )
                .Select( s => ( int? )s.ManyToMany.Count )
                .FirstOrDefault()
        }
