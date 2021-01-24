    public class RelayCommand : ICommand
    {
        private Action<object> mAction;
        
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        
        public RelayCommand(Action<object> action)
        {
            mAction = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            mAction(parameter);
        }
    }
    public class ViewModel
    {
        
        //ignore the argument
        private RelayCommand SetLowPriorityCommand { get => new RelayCommand(_ => SetLowPriority()); }
        //cast and use the argument
        private RelayCommand SetPriority { get => new RelayCommand(priority => SetPriority((int)priority)); }
        private void SetLowPriority()
        {
            //....///
        }
        private void SetPriority(int priority)
        {
            //...//
        }
    }
