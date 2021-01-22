    [Test]
    public void BlogTableAdapter_should_be_called_with_string_having_length_greater_than_1()
    {
        var mockAdapter = new Mock<BLOGTableAdapter>();
        var blogBl = new BlogManagerBLL(mockAdapter.Object);
        blogBl.GetBlogsByBlogTitle("Thanks for reading my question");
        mockAdapter.Verify(x => x.GetBlogsByTitle(It.Is<string>(s => s.Length > 0)));
    }
