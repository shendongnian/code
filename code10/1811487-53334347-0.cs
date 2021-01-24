    public MyView()
    {
        ....
                                             
        Ok_Button.Command = 
            new RelayCommand(() => DialogResult = true, // just setting DialogResult is sufficient, no need to call Close()
                             // put the required validation logic here  
                             () => dxSpinEdit.Value > 0 && dxSpinEdit.Value < 10);
        Cancel_Button.Command = new RelayCommand(() => DialogResult = false);
        // replace this with the actual event from SpinEdit
        dxSpinEdit.ValueChanged += (s,e) => (OK_Button.Command as RelayCommand).RaiseCanExecuteChanged();
    }
