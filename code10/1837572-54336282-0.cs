    [TestMethod]
    public void Add_writes_to_database()
    {
        var options = new DbContextOptionsBuilder<BloggingContext>()
            .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
            .Options;
        // Run the test against one instance of the context
        using (var context = new BloggingContext(options))
        {
            var service = new BlogService(context);
            service.Add("http://sample.com");
        }
        // Use a separate instance of the context to verify correct data was saved to database
        using (var context = new BloggingContext(options))
        {
            Assert.AreEqual(1, context.Blogs.Count());
            Assert.AreEqual("http://sample.com", context.Blogs.Single().Url);
        }
    }
