    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
    public class ViewModel : INotifyPropertyChanged {
        private string _stockValue;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand StartPollingCommand {
            get { return new RelayCommand(param => DoExecuteStartPollingCommand()); }
        }
        private void DoExecuteStartPollingCommand() {
            try {
                Task.Run(() => RunStockParallel("StockName"));
            } catch (Exception ex) {
                //TODO
            }
        }
        private void RunStockParallel(string stockName) {
            var count = 0;
            do {
                
                try {
                    // Do Something to get your Data
                    //HttpWebRequest stocks = null;
                    var stockresults = DateTime.Now;
                    StockValue = stockresults.ToString();
                } catch (Exception e) {
                    //throw e;
                }
                //Wait some time before getting the next stockresults
                Thread.Sleep(1000);
            } while (true);
        }
        public string StockValue {
            get => _stockValue;
            set {
                _stockValue = value;
                OnPropertyChanged();
            }
        }
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class RelayCommand : ICommand {
        #region Fields
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        #endregion // Fields
        #region Constructors
        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null) { }
        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute) {
            if (execute == null)
                throw new ArgumentNullException("execute"); //NOTTOTRANS
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion // Constructors
        #region ICommand Members
        [DebuggerStepThrough]
        public bool CanExecute(object parameter) {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public void Execute(object parameter) {
            _execute(parameter);
        }
        #endregion // ICommand Members
    }
