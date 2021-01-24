    public class MainWindowViewModel
    {
        private readonly IWindowService _windowService;
        public MainWindowViewModel(IWindowService windowService)
        {
            _windowService = windowService;
            CreateWindowCommand = new DelegateCommand(() =>
            {
                _windowService.CreateWindow(new SomeViewModel());
            });
        }
        public ICommand CreateWindowCommand { get; }
    }
