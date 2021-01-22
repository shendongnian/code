    public class Content
    {
        public string Title { get; set; }
        public IList<Content> SubContent
        {
            get;
            private set;
        }
        private Content()
        {
        }
        public Content(string title)
        {
            Title = title;
            SubContent = new List<Content>();
        }
    }
