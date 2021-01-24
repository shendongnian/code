    var publishers = await _db.Publisher
        .Where(e => !e.IsDeleted)
        .Select(e => new PublisherWithMedia()
        {
            Id = e.Id,
            Name = e.Name,
            Mediae = e.Mediae.Select(m => ApiUtils.GetMedia(m)).ToList()
        };
        .ToListAsync();
