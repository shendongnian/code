    private IQueryable QueryProjection(IQueryable<Posting> query)
    {
        return query.Select(p => new
        {
            p.PostingID,
            p.Category.CategoryName,
            p.Type.TypeName,
            p.Status.StatusName,
            p.Description,
            p.Updated,
            p.PostedBy,
            p.ReviewedBy,
        });
    }
