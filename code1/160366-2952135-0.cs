    private PropertyChangedEventHandler _propertyChanged;
    public event PropertyChangedEventHandler PropertyChanged
    {
        add { lock (this.mHandler) { this._propertyChanged += value; } }
        remove { lock (this.mHandler) { this._propertyChanged -= value; } }
    }
    ...
    
    public MainWindow()
    {
        InitializeComponent();
        mHandler.PropertyChanged += mHandler_PropertyChanged;
    }
    
    private void mHandler_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        var handler = _propertyChanged;
        if (handler != null)
            _propertyChanged(this, e);
    }
