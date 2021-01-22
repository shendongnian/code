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
                                        Posts = context.Posts.Where(x=> x.ForumId == f.ForumId)
    
                                    };
    
                    foreach (var forum in allForums)
                    {
                        Console.WriteLine(forum.Forum.Name);
                        if (forum.Posts.AsEnumerable().Count() != 0)
                        {
                            foreach (var post in forum.Posts)
                            {
                                Console.WriteLine(post.PostValue);
                            }
                        }
                        else
                            Console.WriteLine("No Posts");
                    }
                
                }
