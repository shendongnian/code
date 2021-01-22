    public class Content
    {
        public string PageName { get; set; }
    }
    public interface IContentWithSubContent
    {
        IEnumerable SubContent { get; }
    }
    
    public class ContentWithSubContent<T> : Content, IContentWithSubContent
    {
        public IList<T> SubContent { get; set; }
        IEnumerable IContentWithSubContent SubContent 
        { 
            get { return this.SubContent; } 
        }
    }
