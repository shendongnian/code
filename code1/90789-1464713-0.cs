    public class Content
    {
        public string PageName { get; set; }
    }
    
    public class ContentWithSubContent<T> : Content
    {
        public IList<T> SubContent { get; set; }
    }
