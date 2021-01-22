    public class NewsItemListRenderer : NewsItemVisitor
    {
        private readonly List<NewsItem> itemList;
        private string renderedList = string.Empty;
        public NewsItemListRenderer(List<NewsItem> itemList)
        {
            this.itemList = itemList;
        }
        public string Render()
        {
            foreach (var item in itemList)
            {
                item.Accept(this);
            }
            return renderedList;
        }
        public override void Visit(NewsItemJoiner joiner)
        {
            renderedList += "joiner: " + joiner.AccountJoined + Environment.NewLine;
        }
        public override void Visit(NewsItemStatus status)
        {
            renderedList += "status: " + status.Status + Environment.NewLine;
        }
    }
