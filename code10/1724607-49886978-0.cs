    public class CreationDialog : MainPage, IModal
    {
        public CreationDialog()
        {
            _Modal = Modal.Get(WindowLocator);
        }
        IModal _Modal { get; set; }
    }
