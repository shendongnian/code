    string sortBy = HttpContext.Current.Request.QueryString["sidx"];
    ParameterExpression prm = Expression.Parameter(typeof(buskerPosting), "posting");
    Expression orderByProperty = Expression.Property(prm, sortBy);
    // get the paged records
    IQueryable<PostingListItemDto> query = be.buskerPosting
        .Where(posting => posting.buskerAccount.cmsMember.nodeId == m.Id)
        .OrderBy(orderByExpression)
        .Select(posting => new PostingListItemDto { Set = posting })
        .Skip<PostingListItemDto>((page -   1) * pageSize)
        .Take<PostingListItemDto>(pageSize);
