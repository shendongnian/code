    using (var context = new BloggingContext())
    {
        var blog = new Blog
        {
            Url = "http://blogs.msdn.com/dotnet",
            Posts = new List<Post>
            {
                new Post { Title = "Intro to C#" },
                new Post { Title = "Intro to VB.NET" },
                new Post { Title = "Intro to F#" }
            }
        };
    
        context.Blogs.Add(blog);
        context.SaveChanges();
    }
