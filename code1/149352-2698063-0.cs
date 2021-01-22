    public class Page {
        public Page() {
            RevisionId = Guid.Empty;
        }
        protected Page(Guid revisionId) {
            RevisionId = revisionId;
        }
        public Guid RevisionId {
            get;
            private set;
        }
    }
    public class PageRevision : Page {
        public PageRevision()
            : base(Guid.NewGuid()) {
        }
    }
  
