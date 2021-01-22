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
