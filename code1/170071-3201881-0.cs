        //This viewmodel is on the main windows datacontext
    public class ParentViewModel
    {
        private readonly IWindowMediator _mediator;
        public ParentViewModel(IWindowMediator mediator)
        {
            _mediator = mediator;
        }
        public ObservableCollection<Notice> Notices { get; private set; } //bound to list in xaml
        public void OpenNotice(Notice notice)
        {
            //open the window using the Mediator pattern rather than a new window directly
            _mediator.Open(new EditNoticeViewModel(notice, DeleteNotice));
        }
        private void DeleteNotice(Notice notice)
        {
            //This will remove it from the main window list
            Notices.Remove(notice);
        }
    }
    //view model for EditNoticeWindow
    public class EditNoticeViewModel
    {
        public EditNoticeViewModel(Action<Notice> deleteCallback, Notice notice)
        {
            Model = notice;
            DeleteCommand = new DelegateCommand((a) => deleteCallback(Model));
        }
        //Bind in xaml to the Command of a button
        DelegateCommand DeleteCommand { get; private set; }
        //bound to the controls in the xaml.
        public Notice Model { get; private set; }
    }
    //This is a basic interface, you can elaborate as needed
    //but it handles the opening of windows. Attach the view model
    //to the data context of the window.
    public interface IWindowMediator
    {
        void Open<T>(T viewModel);
    }
