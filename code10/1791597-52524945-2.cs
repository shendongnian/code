    public class MainWindowViewModel : INotifyPropertyChanged {
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public ICommand ClickCommand => new RelayCommand(arg => DoExecuteClickCommand());
    
            private void DoExecuteClickCommand() {
                if (LabelVisibility == Visibility.Visible) {
                    LabelVisibility = Visibility.Collapsed;
                } else {
                    LabelVisibility = Visibility.Visible;
                }
                OnPropertyChanged(nameof(LabelVisibility));
            }
    
            public Visibility LabelVisibility { get; set; }
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
