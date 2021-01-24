    public class MainWindowViewModel
    {
        private readonly IWindowService _service;
        public MainWindowViewModel (IWindowService service)
        {
            _service = service;
        }
        //...
        public void OpenWindowExecuted()
        {
            _service.ShowWindow();
        }
    }
