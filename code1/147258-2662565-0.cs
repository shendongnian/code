    using (var session = new Session<ContextItem>())
    {
        var allByDateReverse =
            session.QueryCollection.OrderByDescending(x => x.CreatedOn);
        ViewData.Model = allByDateReverse.ToList();
    }
