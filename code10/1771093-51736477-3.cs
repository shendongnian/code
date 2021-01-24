    public class ViewModel : INotifyPropertyChanged
    {
        private bool asyncCommandWorking;
        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        public ViewModel()
        {
            AsyncCommand = new AsyncRelayCommand(Execute, CanExecute);
        }
        private Task Execute(object obj)
        {
            return Task.Run(() =>
            {
                // do some work...
            });
        }
        private bool CanExecute(object obj)
        {
            AsyncCommandWorking = AsyncCommand.IsWorking;
            // process other can execute logic.
            // return the result of CanExecute or not
        }
        public AsyncRelayCommand AsyncCommand { get; }
        public bool AsyncCommandWorking
        {
            get => asyncCommandWorking;
            private set
            {
                asyncCommandWorking = value;
                Notify();
            }
        }
    }
