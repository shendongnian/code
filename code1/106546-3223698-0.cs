    [Test]
    public void Should_show_each_post_with_most_recent_first_using_sequences()
    {
        var olderPost = new Post { DateTime = new DateTime(2010, 1, 1) };
        var newerPost = new Post { DateTime = new DateTime(2010, 1, 2) };
        var posts = new List<Post> { newerPost, olderPost };
    
        var mockView = new Mock<BlogView>();
    
        using (Sequence.Create())
        {
            mockView.Setup(v => v.ShowPost(newerPost)).InSequence();
            mockView.Setup(v => v.ShowPost(olderPost)).InSequence();
    
            new BlogPresenter(mockView.Object).Show(posts);
        }
    }
