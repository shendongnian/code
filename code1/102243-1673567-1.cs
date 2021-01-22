    public class News
    {
        public News(SomeCollection<Image> images)
        {
            _images = images;
            Images = new ListView(this);
        }
    
        private SomeCollection<Image> _images;
    
        public IList<Image> Images { get; private set; }
    
        private class News.ListView : IList<Image>
        {
            public ListView(News news)
            {
                _news = news;
            }
    
            private News _news;
    
            // Implement the methods to manipulate _news._images
        }
    }
