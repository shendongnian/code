    from b in Context.Bands
    where b.Name.Contains(search)
    group b by band.MusicStyle into g
    select new {
        Style = g.Key,
        Bands = g
    }
    from b in Context.Bands
    where b.Name.Contains(search)
    select new {
        BandName = b.Name,
        MusicStyleId = b.MusicStyle.Id,
        MusicStyleName = b.MusicStyle.Name,
        // etc.
    }
