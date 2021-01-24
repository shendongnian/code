    private bool _CheckBoxChecked;
    public bool CheckBoxChecked
    {
        get { return _CheckBoxChecked; }
        set { _CheckBoxChecked = value; 
              OnPropertyChanged("CheckBoxChecked"); 
              OnPropertyChanged("PortsCollection"); 
             }
    }
