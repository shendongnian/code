    public class PlusCommand : ICommand
    {
        private YourViewModelClass viewModel;
        public PlusCommand(YourViewModelClass vm)
        {
            viewModel = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            //Your code to run here. Access viewmodel by viewModel variable.
        }
    
        public event EventHandler CanExecuteChanged;
    }
