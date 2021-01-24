    [TestMethod] 
        public void CreateBlog_saves_a_blog_via_context() 
        { 
            var mockSet = new Mock<DbSet<Blog>>(); 
 
            var mockContext = new Mock<BloggingContext>(); 
            mockContext.Setup(m => m.Blogs).Returns(mockSet.Object); 
 
            var service = new BlogService(mockContext.Object); 
            service.AddBlog("ADO.NET Blog", "http://blogs.msdn.com/adonet"); 
 
            mockSet.Verify(m => m.Add(It.IsAny<Blog>()), Times.Once()); 
            mockContext.Verify(m => m.SaveChanges(), Times.Once()); 
        } 
