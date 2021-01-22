    public void AuthentifyEmp(object obj)
    {
        var passwordBox = obj as PasswordBox;
        var password = passwordBox.Password;
    }
    private RelayCommand _authentifyEmpCommand;
    public RelayCommand AuthentifyEmpCommand => _authentifyEmpCommand ?? (_authentifyEmpCommand = new RelayCommand(AuthentifyEmp, null));
