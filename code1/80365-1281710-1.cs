    public class ProjectViewModel
    {
        private readonly ICollection<PageViewModel> _pages;
        private readonly ICommand _addPageCommand;
    
        public ProjectViewModel()
        {
            _pages = new ObservableCollection<PageViewModel>();
            _addPageCommand = new DelegateCommand(AddPage);
        }
        public ICommand AddPageCommand
        {
            get { return _addPageCommand; }
        }
    
        private void AddPage(object state)
        {
            _pages.Add(new PageViewModel());
        }
    }
