    .Select( l => new MyEntityDto
    {
        Id = l.Id,
        RuleCount = ( int? )l.MyLinkedEntity
            .Where( s => s.MyBoolean )
            .OrderByDescending( s => s.CreatedDateUtc )
            .FirstOrDefault()
            ?.MyManyToMany
            ?.Count
    }
