    [TestFixture]
    public class TestClass
    {
        [Test]
        public void Test1()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Blog, BlogViewModel>();
            });
            config.AssertConfigurationIsValid();
            var blog = new Blog()
            {
                Body = "Blog body",
                Category = new Category { Name = "My Category" },
                Comments = new List<Comment>() {
                    new Comment { Body = "Comment body 1" },
                    new Comment { Body = "Comment body 2" }
                }
            };
            var mapper = config.CreateMapper();
            var result = mapper.Map<Blog, BlogViewModel>(blog);
            Assert.AreEqual(blog.Body, "Blog body");
            Assert.AreEqual(blog.Category.Name, result.CategoryName);
            List<CommentViewModel> comments = result.Comments.ToList();
            Assert.That(comments.Any(c => c.Body == "Comment body 1"));
            Assert.That(comments.Any(c => c.Body == "Comment body 2"));
        }
    }
