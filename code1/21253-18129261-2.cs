    static void Main()
    {
        using (var ctx = new BloggingContext())
        {
            // insert some data
            var blog  = new Blog(){Name = "blog"};
            blog.Posts = new List<Post>() 
                { new Post() { Title = "new post 1", PostDate = DateTime.Parse("01/01/2001") } };
            blog.Posts = new List<Post>()
                { new Post() { Title = "new post 2", PostDate = DateTime.Parse("01/01/2002") } };
            blog.Posts = new List<Post>() 
                { new Post() { Title = "new post 3", PostDate = DateTime.Parse("01/01/2003") } };
            ctx.Blogs.Add(blog);
            blog = new Blog() { Name = "blog 2" };
            blog.Posts = new List<Post>()
                { new Post() { Title = "new post 1", PostDate = DateTime.Parse("01/01/2001") } };
            ctx.Blogs.Add(blog);
            ctx.SaveChanges();
            // first, do a hard-coded Where() with Any(), to demonstrate that that Linq-to-SQL can
            // handle it
            var cutoffDateTime = DateTime.Parse("12/31/2001");
            var hardCodedResult = 
                ctx.Blogs.Where((b) => b.Posts.Any((p) => p.PostDate > cutoffDateTime));
            var hardCodedResultCount = hardCodedResult.ToList().Count;
            Debug.Assert(hardCodedResultCount > 0);
            // now do a logically equivalent Where() with Any(), but programmatically build the
            // expression tree
            var blogsWithRecentPostsExpression = 
                BuildExpressionForBlogsWithRecentPosts(cutoffDateTime);
            var dynamicExpressionResult = ctx.Blogs.Where(blogsWithRecentPostsExpression);
            var dynamicExpressionResultCount = dynamicExpressionResult.ToList().Count;
            Debug.Assert(dynamicExpressionResultCount > 0);
            Debug.Assert(dynamicExpressionResultCount == hardCodedResultCount);
        }
    }
