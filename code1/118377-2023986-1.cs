    public class Page
    {
        private PublishingStateMachine sm = new
            PublishingStateMachine(PublishingState.Unpublished);
        private string title;
        private string category;
        // Snip other methods/properties
        // ...
        public string Title
        {
            get { return title; }
            set { sm.Write(() => title = value; }
        }
        public string Category
        {
            get { return category; }
            set { sm.Write(() => category = value; }
        }
        public PublishingState State
        {
            get { return sm.State; }
            set { sm.State = value; }
        }
    }
