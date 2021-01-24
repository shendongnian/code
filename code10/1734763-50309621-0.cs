    public bool Spin 
    {
        get { return _spin; }
        set {
            if (value == false) this.spinBack = true;
            _spin = value;
        }
    }
    
    private bool _spin;
    private bool spinBack;
