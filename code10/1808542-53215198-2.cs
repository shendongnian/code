    public static void InsertOrUpdateGraph(BloggingContext context, Blog blog)
    {
        var existingBlog = context.Blogs
            .Include(b => b.Posts)
            .FirstOrDefault(b => b.BlogId == blog.BlogId);
    
        if (existingBlog == null)
        {
            context.Add(blog); //or 404 response, or custom exception, etc...
        }
        else
        {
            context.Entry(existingBlog).CurrentValues.SetValues(blog);
            foreach (var post in blog.Posts)
            {
                var existingPost = existingBlog.Posts
                    .FirstOrDefault(p => p.PostId == post.PostId);
    
                if (existingPost == null)
                {
                    existingBlog.Posts.Add(post);
                }
                else
                {
                    context.Entry(existingPost).CurrentValues.SetValues(post);
                }
            }
        }
    
        context.SaveChanges();
    }
