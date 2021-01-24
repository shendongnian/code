    public ICommand OpenFolderCommand { get; private set; }
    public MyViewModel() 
    {
    	this.OpenFolderCommand = new RelayCommand(a=> this.OpenFolder(),p=> CanOpenFolder());
    }
