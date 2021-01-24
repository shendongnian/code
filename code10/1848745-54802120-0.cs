    s => s
    .Sort(ss => ss
        .Ascending(p => p.StartedOn)
        .Descending(p => p.Name)
        .Descending(SortSpecialField.Score)
        .Ascending(SortSpecialField.DocumentIndexOrder)
        .Field(f => f
            .Field(p => p.Tags.First().Added)
            .Order(SortOrder.Descending)
            .MissingLast()
            .UnmappedType(FieldType.Date)
            .Mode(SortMode.Average)
            .NestedPath(p => p.Tags)
            .NestedFilter(q => q.MatchAll())
        )
        .Field(f => f
            .Field(p => p.NumberOfCommits)
            .Order(SortOrder.Descending)
            .Missing(-1)
        )
        .GeoDistance(g => g
            .Field(p => p.Location)
            .DistanceType(GeoDistanceType.Arc)
            .Order(SortOrder.Ascending)
            .Unit(DistanceUnit.Centimeters)
            .Mode(SortMode.Min)
            .Points(new GeoLocation(70, -70), new GeoLocation(-12, 12))
        )
        .Script(sc => sc
            .Type("number")
            .Ascending()
            .Script(script => script
                .Source("doc['numberOfCommits'].value * params.factor")
                .Params(p => p.Add("factor", 1.1))
            )
        )
    )
