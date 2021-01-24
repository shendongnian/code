    public class AsyncRelayCommand : ICommand
    {
        public Action<object> ExecuteFunction { get; }
        public Predicate<object> CanExecutePredicate { get; }
        public event EventHandler CanExecuteChanged;
        public void UpdateCanExecute() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool IsWorking { get; private set; }
        public AsyncRelayCommand(Action<object> executeFunction) : this(executeFunction, (obj) => true) { }
        public AsyncRelayCommand(Action<object> executeFunction, Predicate<object> canExecutePredicate)
        {
            ExecuteFunction = executeFunction;
            CanExecutePredicate = canExecutePredicate;
        }
        public bool CanExecute(object parameter) => !IsWorking && (CanExecutePredicate?.Invoke(parameter) ?? true);
        public async void Execute(object parameter)
        {
            IsWorking = true;
            UpdateCanExecute();
            await Task.Run(() => ExecuteFunction.Invoke(parameter));
            IsWorking = false;
            UpdateCanExecute();
        }
    }
