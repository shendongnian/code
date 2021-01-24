    public string Username {
        get { return _username; }
        set {
            _username = value;
            NotifyOfPropertyChange("Username");
            SaveCommand.RaiseCanExecuteChanged();
        }
    }
    public string Password {
        get { return _password; }
        set {
            _password = value;
            NotifyOfPropertyChange("Password");
            SaveCommand.RaiseCanExecuteChanged();
        }
    }
