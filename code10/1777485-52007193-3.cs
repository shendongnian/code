    // Perform query and map to DTO
    var res = (await query.ToListAsync()).Select(n =>
    {
        var lonLat = n.Location.Coordinates.Values.ToArray();
    
        return new NodeBase
        {
            Id = n.Id.ToString(),
            Location = new SimpleGeoJsonPoint
            {
                Lon = lonLat[0],
                Lat = lonLat[1],
            },
            Tags = n.Tags.ToDictionary(),
        };
    });
    
    return Ok(new MultiSearchResult<NodeBase>
    {
        Count = res.Count(),
        Results = res,
    });
