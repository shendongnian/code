    public class CreationDialog : MainPage, IModal
    {
        public CreationDialog()
        {
            _Modal = Modal.Get(WindowLocator);  //Don't declare new variable
        }
    
        IModal _Modal { get; set; }
    }
