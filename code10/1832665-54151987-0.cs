    private int _prop1;
    
    //#1
    public event System.EventHandler PropertyChanged;
    
    //#2
    protected virtual void OnPropertyChanged()
    { 
         if (PropertyChanged != null) PropertyChanged(this,EventArgs.Empty); 
    }
    
    public int Prop1
    {
        get
        {
             return _prop1;
        }
    
        set
        {
             //#3
             _prop1=value;
             OnPropertyChanged();
        }
     }
