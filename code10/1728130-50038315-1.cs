    public Test TestVM
    {
        get { return testVM; }
        set
        {
            Test oldValue = testVM;
            if (SetProperty(ref testVM, value))
            {
                if (oldValue != null)
                {
                    oldValue.PropertyChanged -= TestPropertyChanged;
                }
                if (testVM!= null)
                {
                    testVM.PropertyChanged += TestPropertyChanged;
                }
            }
        }
    }
    void TestPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        // filter if necessary
        if (e.PropertyName == "...")
        {
            StartTestCommand.RaiseCanExecuteChanged();
        }
    }
