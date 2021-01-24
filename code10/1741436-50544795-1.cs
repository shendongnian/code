    public class MainViewModel
    {
        public ExampleClass ExampleInstance { get; set; }
        public ICommand SaveCommand { get; set; }
        public MainViewModel()
        {
            ExampleInstance = new ExampleClass() { ExampleName = "Example Name" };
            SaveCommand = new SaveCommand(this);
        }
        internal void Save()
        {
            //TO DO  - Save item to database
            Console.WriteLine(ExampleInstance.ExampleName);
        }
    }
    public class ExampleClass : INotifyPropertyChanged
    {
        private string _exampleName;
        public string ExampleName
        {
            get { return _exampleName; }
            set
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(ExampleName)));
                _exampleName = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
    public class SaveCommand : ICommand
    {
        private MainViewModel _vm;
        public event EventHandler CanExecuteChanged;
        public SaveCommand(MainViewModel vm)
        {
            _vm = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _vm.Save();
        }
    }
