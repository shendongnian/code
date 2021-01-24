    private bool _buttonVisibility;
    public bool ButtonVisibility
    {
    	get { return _buttonVisibility; }
    	set { _buttonVisibility = value; OnPropertyChanged(nameof(ButtonVisibility)); }
    }
    
    private Command<string> _ImageTapCommand;
    public Command<string> ImageTapCommand
    {
    	get
    	{
    		return _ImageTapCommand ?? (_ImageTapCommand = new Command<string>((str) => ImageTapCommandExecute(str)));
    	}
    }
    
    void ImageTapCommandExecute(string str)
    {
        //Here str is whatever you passed with CommandParameter.
        //When your Image is tapped, button gets visible
        ButtonVisibility = true;    			
    }
