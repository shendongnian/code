    private int _studentId;
    
    public int StudentId 
    { 
        get { return _studentId; }
        set
        {
            SetProperty(ref _studentId, value);
            RaisePropertyChanged("StudentIdString"); // If you're using Prism. You can use any other way to raise the PropertyChanged event 
        }
    }
    
    public string StudentIdString
    {
        get { return StudentId.ToString(); }
    }
