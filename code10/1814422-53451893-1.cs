        private static void TestInsert2()
        {
         using (DefaultDB ctx = new DefaultDB())
         {
           RegularAuthor author1 = new RegularAuthor()
           {
             Name = "First Author",
             Address = GetLocalIpAddress(),
             DateOfFirstBlogPost = DateTime.Now
           };
           GuestAuthor guest1 = new GuestAuthor()
           {
            Name = "Second Author",
            Address = GetLocalIpAddress(),
            OriginalBlogAccess = "Never"
           };
    
        author1.Blogs = new List<Blog>
        {
           new Blog        
           {
             Author = author1,
             BlogTitle = "Mid Century Modern DIY Dog House Build"
           },
            new Blog
           {
             Author = author1,
             BlogTitle = "5 Ways to Make Giant Candy for a Candyland Theme"
           }
        }
    
        guest1.Blogs = new List<Blog>
        {
           new Blog
           {
             Author = guest1,
             BlogTitle = "Elf Doughnut Box Printable"
           }
        }
        context.Add(author1);
        context.Add(guest1);
        ctx.SaveChanges();
        }
       }
