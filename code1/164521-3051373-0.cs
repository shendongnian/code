    public B MemberOfA {
        get { return _b; }
        set {
    
            if (_b != null) { _b.PropertyChanged -= B_PropertyChanged; }
    
            _b = value;
    
            if (_b != null) { _b.PropertyChanged += B_PropertyChanged; }
    
            DoWhatever(_b);
    
        }
    }
    
    private void B_PropertyChanged(object sender, PropertyChangedEventArgs e) {
        DoWhatever((B)sender);
    }
