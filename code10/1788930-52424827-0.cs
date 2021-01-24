    public BlogPost GetBlogPostById(int id, bool includePostTags)
    {
        if(includePostTags)
        {
            return _context.BlogPosts.Where(c => c.Id == id).Select(bp =>
                    new BlogPostDto
                    {
                        Id = bp.Id,
                        Title = bp.Title,
                        .......
                        Tags = bp.BlogPostTags.Select(t => new BlogPostTagDto {
                                 Id = t.Id,
                                 ....
                               }).ToList()
                    }).FirstOrDefault();
        }
        return _context.BlogPosts.Where(c => c.Id == id).Select(bp =>
                    new BlogPostDto
                    {
                        Id = bp.Id,
                        Title = bp.Title,
                        .......
                    }).FirstOrDefault();
    }
