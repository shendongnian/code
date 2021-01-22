    public abstract class RenderableNewsItem : NewsItem
    {
        abstract public string Render();
    }
    
    public class NewsItemStatus : RenderableNewsItem 
    { 
        public virtual string Status { get; set; } 
        public string Render() 
        { 
            return String.Format("<span class='statusupdate'>{0}<span>", this.Status); 
        } 
    }
