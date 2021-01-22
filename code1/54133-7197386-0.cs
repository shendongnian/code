    public class TestCommand : ICommand
    {
        public void Execute(object parameter)
        {
            _CanExecute = false;
            OnCanExecuteChanged();
            Thread.Sleep(1000);
            Console.WriteLine("Executed TestCommand.");
            _CanExecute = true;
            OnCanExecuteChanged();
        }
        private bool _CanExecute = true;
        public bool CanExecute(object parameter)
        {
            return _CanExecute;
        }
        private void OnCanExecuteChanged()
        {
            EventHandler h = CanExecuteChanged;
            if (h != null)
            {
                h(this, EventArgs.Empty);
            }
        }
        public event EventHandler CanExecuteChanged;
    }
