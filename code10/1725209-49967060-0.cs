    private static IQueryable<MultiframeModule> WhereAllFramesProperties(this IQueryable<MultiframeModule> query, ICollection<Frame> frames)
    {
        var values = frames.Select(e => e.FrameData.ShaHash);
        var count = frames.Count();
        return query.Where(p => p.Frames.Select(e => e.FrameData.ShaHash)
            .Distinct().Count(v => values.Contains(v)) == count);
    }
