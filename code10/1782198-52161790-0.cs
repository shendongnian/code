    public class Article
    {
        private string content;
        private string renderedContent;
        public string Headline { get; set; }
        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                renderedContent = null; // reset cached rendered content
            }
        }
        public string RenderedContent
        {
            get
            {
                if (renderedContent == null)
                {
                    renderedContent = new Markdown().Transform(value);
                }
                return renderedContent;
            }
        }
        public DateTime Published { get; set; } = DateTime.Now;
    }
