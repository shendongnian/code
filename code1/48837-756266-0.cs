    private EventHandler myPropertyChangedDelegate;
    
    public event EventHandler MyPropertyChanged
    {
        add { myPropertyChangedDelegate += value; }
        remove { myPropertyChangedDelegate -= value; }
    }
