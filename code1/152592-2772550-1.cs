    //custom return class 
       public class ForumPosts 
        {
            public Forum Forum { get; set; }
            public IQueryable<Post> Posts { get; set; }
        }
    
    using (ClassLibrary1.Entities context = new Entities())
                { 
                    var allForums = from f in context.Fora
                                    select new ForumPosts
                                    {
                                        Forum = f,
                                        Posts = context.Posts.Where(x=> x.ForumId == f.ForumId) == null ? new List<Post>(){new Post{ default values}} : context.Posts.Where(x=> x.ForumId == f.ForumId)
                                    };
    
                    foreach (var forum in allForums)
                    {
                        Console.WriteLine(forum.Forum.Name);
                        foreach (var post in forum.Posts)
                        {
                            Console.WriteLine(post.PostValue);
                        }
                    }
                
                }
