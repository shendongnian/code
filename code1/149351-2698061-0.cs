    public class PageRevision : Page
    {
        private readonly Page page;
        private readonly Guid id;
        public Guid RevisionID { get { return id; } }
        public Page Page { get { return page; } }
    
        public PageRevision(Page page)
        {
            this.id = Guid.NewGuid();
            this.page = page;
        }
    }
