    public class ViewModel
    {
        private readonly Model _model;
        public ViewModel(Model model)
        {
            _model = model;
            command = new RelayCommand(Execute, CanExecute);
        }
        public string Input { get; set; }
        public string Output { get; set; }
        public ICommand command { get; private set; }
        private bool CanExecute(object _)
        {
            return !string.IsNullOrEmpty(Input);
        }
        private void Execute(object _)
        {
            Output = _model.FancyMethod(Input);
        }
    }
