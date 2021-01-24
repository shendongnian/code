        public partial class MainWindow : Window {
            public MainWindow() {
                InitializeComponent();
                DataContext = new MainWindowViewModel();
            }
        }
    
        public class MainWindowViewModel : INotifyPropertyChanged {
            private string _ipAdrress;
            private bool _errorOccured;
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public string IpAddress => _ipAdrress;
            public Brush IpForeground => _errorOccured ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Black);
    
            public ICommand GetIpCommand {
                get { return new RelayCommand(param => DoExecuteGetIpCommand()); }
            }
    
            private async void DoExecuteGetIpCommand() {
                try {
                    _errorOccured = false;
                    _ipAdrress = await MyService.GetIpAddress();
                } catch (Exception ex) {
                    _errorOccured = true;
                    _ipAdrress = ex.Message;
                }
                OnPropertyChanged(nameof(IpAddress));
                OnPropertyChanged(nameof(IpForeground));
            }
        }
    
        internal class MyService {
            private static bool _dummySucces = false;
            public async static Task<string> GetIpAddress() {
                //TODO Code to get IP in async manner...
                _dummySucces = !_dummySucces;
                
                if (!_dummySucces) {
                    throw new Exception("Error occured...");
                }
                return "1.1.1.1";
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
                : this(execute, null) {
            }
    
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
