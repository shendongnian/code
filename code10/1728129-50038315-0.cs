    public Test TestVM
    {
        get { return testVM; }
        set
        {
            SetProperty(ref testVM, value);
            StartTestCommand.RaiseCanExecuteChanged();
        }
    }
