    using (var context = new BloggingContext())
    {
        var blogs = context.Blogs
            .Include(blog => blog.Posts)
                .ThenInclude(post => post.Author)
            .Include(blog => blog.Posts)
                .ThenInclude(post => post.Tags)
            .ToList();
    }
