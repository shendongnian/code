    public abstract class NewsItem
    {
        public virtual string Account { get; set; }
        public virtual DateTime DateTime { get; set; }
        public abstract void Accept(NewsItemVisitor visitor);
    }
    public class NewsItemJoiner : NewsItem
    {
        public virtual string AccountJoined { get; set; }
        public override void Accept(NewsItemVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class NewsItemStatus : NewsItem
    {
        public virtual string Status { get; set; }
        public override void Accept(NewsItemVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
