     public class ForumPosts 
        {
            public Forum Forum { get; set; }
            public IQueryable<Post> Posts { get; set; }
        }
    
        public class DisplaySet 
        {
            public string Name { get; set; }
            public string PostTile { get; set; }
        } 
 
              //left outer join
                using (ClassLibrary1.Entities context = new Entities())
                {
                    var allForums = from f in context.Fora
                                    select new ForumPosts
                                    {
                                        Forum = f,
                                        Posts = context.Posts.Where(x=> x.ForumId == f.ForumId)
    
                                    };
                    List<DisplaySet> ds = new List<DisplaySet>();
    
                    foreach (var forum in allForums)
                    {
                        if (forum.Posts.AsEnumerable().Count() != 0)
                        {
                            foreach (var post in forum.Posts)
                            {
                               ds.Add(new DisplaySet(){ Name = forum.Forum.Name, PostTile = post.PostValue});
                            }
                        }
                        else
                            ds.Add(new DisplaySet(){ Name = forum.Forum.Name, PostTile = string.Empty});
                    }
    
                    foreach (var item in ds)
    	            {
    		            Console.WriteLine(string.Format("{0} || {1}",item.Name,item.PostTile));
    	            }
    
              
                }
    
    
    
    //This produces the following LINQ query which is right
    SELECT 
    [Project1].[ForumId] AS [ForumId], 
    [Project1].[Name] AS [Name], 
    [Project1].[C1] AS [C1], 
    [Project1].[PostId] AS [PostId], 
    [Project1].[PostValue] AS [PostValue], 
    [Project1].[ForumId1] AS [ForumId1]
    FROM ( SELECT 
    	[Extent1].[ForumId] AS [ForumId], 
    	[Extent1].[Name] AS [Name], 
    	[Extent2].[PostId] AS [PostId], 
    	[Extent2].[PostValue] AS [PostValue], 
    	[Extent2].[ForumId] AS [ForumId1], 
    	CASE WHEN ([Extent2].[PostId] IS NULL) THEN CAST(NULL AS int) ELSE 1 END AS [C1]
    	FROM  [dbo].[Forum] AS [Extent1]
    	LEFT OUTER JOIN [dbo].[Post] AS [Extent2] ON [Extent2].[ForumId] = [Extent1].[ForumId]
    )  AS [Project1]
    ORDER BY [Project1].[ForumId] ASC, [Project1].[C1] ASC
