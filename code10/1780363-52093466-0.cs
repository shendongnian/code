    var blogs = _dbContext.Blogs.Include(b => b.Posts).ThenInclude(b => b.PostType)
        .Where(b => b.Posts.Count == 0 || b.Posts.Any(p => p.PostType.Code == "Code1").ToList(); 
    // blogs contains posts which have Code1, and maybe Code2
    
    //filter the posts by assigning only the posts with Code1
    blogs.ForEach(b=> b.Posts = b.Posts.Where( p => p.PostType.Code == "Code1"))
