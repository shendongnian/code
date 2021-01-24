    // Find (load from the database) the existing post
    var existingPost = await dbContext.Posts
        .SingleOrDefaultAsync(p => p.Id == post.Id);
    if (existingPost == null)
    {
        // Handle the invalid call
        return;
    }
    
    // Apply primitive property modifications
    dbContext.Entry(existingPost).CurrentValues.SetValues(post);
    
    // Apply many-to-many link modifications
    dbContext.Set<PostCategory>().UpdateLinks(pc => pc.PostId, post.Id, 
        pc => pc.CategoryId, post.PostCategories.Select(pc => pc.CategoryId));
    
    // Apply all changes to the db
    await dbContext.SaveChangesAsync();
