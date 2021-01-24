    public class CreationDialog : MainPage, IModal
    {
        public CreationDialog()
        {
            IModal _Modal = Modal.Get(WindowLocator);
        }
    
        IModal _Modal { get; set; }
    }
