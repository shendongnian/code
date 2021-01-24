    var sets = new List<IEnumerable<string>>    
    {
        new string[]{ "A", "B", "C", "D", "E", "F" },
        new string[]{ "A", "B", "B", "C", "D", "D", "D", "E", "F" },
        ... etc ...
    };
    var valueMaxCounts = sets
        .Select( s =>
            s.GroupBy( v => v )
                .Select( g => new
                {
                    Value = g.Key,
                    Count = g.Count(),
                } ) )
        .GroupBy( at => at.Value )
        .Select( g => new
        {
            Value = g.Key,
            Count = g.Max( at => at.Count ),
        } );
