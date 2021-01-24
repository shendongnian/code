    // In your DevblogModels and assuming a 1:1 relationship
    public void SetNewsReport(NewsReport newsReport)
    {   
        this.News.UpdateFrom(newsReport);
    }
    // Then, on your NewsReport entity
    internal void UpdateFrom(NewsReport other)
    {
        this.Title = other.Title;
        this.Article = other.Article;
        // other properties...
    }
