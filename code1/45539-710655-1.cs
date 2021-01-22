    var query = from b in context.Blogs
                //probably some where you already have
                select new MyBlogs // or with no type in case it is anonymous
                {
                    AColumn = b.AColumn, //map any other values
                    LatestPost = b.Posts.Where(
                          p1 => p1.SomeColumn == b.Posts.Max(p2 => p2. SomeColumn)
                      )).ToList()
                }
