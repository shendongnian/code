    private ICommand _VolumeChangedCommand;
    public ICommand VolumeChangedCommand
    {
        get
        {
            if (_VolumeChangedCommand == null)
                _VolumeChangedCommand = new CommandImplement();
            return _VolumeChangedCommand ;
        }
        set
        {
            _VolumeChangedCommand = value;
        }
    }
    
    class CommandImplement: ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        } 
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        } 
    
        public void Execute(object parameter)
        {
             VolumeChanged(); //Call your method or put your code here.
        }
    }
