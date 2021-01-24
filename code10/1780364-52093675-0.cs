    var blogs = _dbContext.Blogs.Include(b => b.Posts).ThenInclude(b => b.PostType)
        .Where(b => b.Posts.Count == 0 || b.Posts.Any(p => p.PostType.Code == "Code1")
        .ToList(); 
    // Storing the filterd posts in a dictionary to avoid side-effects of EF tracking.
    var dictionary = new Dictionary<int, List<Post>>();
    foreach (var blog in blogs) {
        dictionary[blog.BlogId] = blog.Posts.Where(p => p.PostType.Code == "Code1").ToList();
    }
