    using (var context = new BloggingContext())
    {
        context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    
        var blogs = context.Blogs.ToList();
    }
