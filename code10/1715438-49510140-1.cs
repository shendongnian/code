     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
    public class MainViewModel:INotifyPropertyChanged
    {
        public List<string> Country { get; set; } = new List<string>
        {
            "USA",
            "CANADA",
            "FRANCE",
            "GERMAN",
            "JAPAN",
            "ITALY",
            "UKARAINE",
            "POLAND",
            "GREAT BRITAIN",
            "TURKEY"
        };
        public ObservableCollection<string> SelectedCountry { get; set; } = new ObservableCollection<string>();
        public ICommand SelectedCountryCommand =>
            _selectedCountryCommand ?? (_selectedCountryCommand = new RelayCommand(
                param =>
                {
                    SelectedCountry.Clear();
                    SelectedCountry.Add((param as SelectionChangedEventArgs).AddedItems[0].ToString());
                }));
        private ICommand _selectedCountryCommand;
        //INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
    public class InteractiveCommand : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            if (AssociatedObject == null)
                return;
            var command = ResolveCommand();
            if (command != null && command.CanExecute(parameter))
            {
                command.Execute(parameter);
            }
        }
        private ICommand ResolveCommand()
        {
            ICommand command = null;
            if (Command != null)
            {
                return Command;
            }
            if (AssociatedObject != null)
            {
                foreach (var info in AssociatedObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (typeof(ICommand).IsAssignableFrom(info.PropertyType) && string.Equals(info.Name, CommandName, StringComparison.Ordinal))
                    {
                        command = (ICommand)info.GetValue(AssociatedObject, null);
                    }
                }
            }
            return command;
        }
        private string _commandName;
        public string CommandName
        {
            get
            {
                ReadPreamble();
                return _commandName;
            }
            set
            {
                if (CommandName == value)
                    return;
                WritePreamble();
                _commandName = value;
                WritePostscript();
            }
        }
        #region Command
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(InteractiveCommand), new UIPropertyMetadata(null));
        #endregion
    }
