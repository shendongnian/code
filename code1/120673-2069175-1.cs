    [Test]
    public void BlogTableAdapter_should_return_a_BLOGDataTable_object()
    {
        var mockAdapter = new Mock<BLOGTableAdapter>();
        mockAdapter.Setup(x => x.GetBlogsByTitle(It.Is<string>(s => s.Length > 0))).Returns(new BLOGDataTable());
        var blogBl = new BlogManagerBLL(mockAdapter.Object);
        var returnValue = blogBl.GetBlogsByBlogTitle("Thanks for reading my question");
        Assert.That(returnValue, Is.TypeOf(typeof(BLOGDataTable)));
    }
