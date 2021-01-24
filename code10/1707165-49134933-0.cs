    public class Icom : ICommand
    {
        public ViewM VieM { get; set; }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
        public Icom(ViewM view)
        {
            this.VieM = view;
        }
        public bool CanExecute(object parameter)
        {
            Repository R = (Repository)parameter;
            if (R != null)
            {
                if (string.IsNullOrEmpty(R.ID) || (string.IsNullOrEmpty(R.Name)))
                    return false;
                return true;
            }
            return false;
        }
        public void Execute(object parameter)
        {
            VieM.Wy();
        }
    }
