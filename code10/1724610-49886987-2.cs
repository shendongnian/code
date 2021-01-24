    public class CreationDialog : MainPage, IModal
    {
        protected readonly IModal _modal;
        public CreationDialog()
        {
            _modal = Modal.Get(WindowLocator);  //Don't declare new variable
        }
    
        public IModal Modal
        {
            get { return _modal; }
        }
    }
