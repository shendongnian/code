    private MyModel _model;
    public MyModel Model
    {
        get { return _model; }
        set   
        {
             _model = value;
             OnPropertyChanged("Model");
        }
    }
