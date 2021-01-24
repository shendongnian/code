    class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
    
        private readonly Predicate<object> canExecute;
        private ICommand setCommand;
    
        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }
    
        public RelayCommand(ICommand setCommand)
        {
            this.setCommand = setCommand;
        }
    
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                // ReSharper disable once LocalizableElement
                throw new ArgumentNullException(nameof(execute), "Execute method missing");
            }
    
            this.execute = execute;
            this.canExecute = canExecute;
        }
    
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
    
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    
        public bool CanExecute(object parameter)
        {
            return this.canExecute?.Invoke(parameter) ?? true;
        }
    
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
