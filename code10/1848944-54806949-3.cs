    private ObservableCollection<TestStep> testSteps;
    public ObservableCollection<TestStep> TestSteps
    {
        get { return testSteps; }
        set
        {
            testSteps = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TestSteps)));
        }
    }
