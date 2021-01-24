    public string FirstName {
        get {
            return _firstName;
        }
        set {
            _firstName = value;
            NotifyOfPropertyChange(() => FirstName);
            NotifyOfPropertyChange(() => CanClearText);
        }
    }
    public bool CanClearText {
        get {
            return !string.IsNullOrEmpty(FirstName);
        }
    }
    
    public void ClearText() {
        FirstName = "";
    }
