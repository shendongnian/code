    using (var context = new BlogContext())
    {
        context.ResetValueGenerators();
        context.Database.EnsureDeleted();
    
        context.Posts.Add(new Post {Title = "Open source FTW", Blog = new Blog {Title = "One Unicorn"}});
        context.SaveChanges();
    }
