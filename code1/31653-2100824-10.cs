    public abstract class WorkspaceViewModel : ViewModelBase
    // There's nothing interesting in ViewModelBase as it only implements the INotifyPropertyChanged interface
    {
        RelayCommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(
                       param => Close(),
                       param => CanClose()
                       );
                }
                return _closeCommand;
            }
        }
        public event Action RequestClose;
        public virtual void Close()
        {
            if ( RequestClose != null )
            {
                RequestClose();
            }
        }
        public virtual bool CanClose()
        {
            return true;
        }
    }
