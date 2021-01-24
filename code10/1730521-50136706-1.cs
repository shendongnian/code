    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        // [...]
    
        _fab = root.FindViewById<FloatingActionButton>(...);
        _fab.Click += ((sender, v) =>  TestAsync("fab"));
    
        // [...]
    }
    
    private async void TestAsync(string origin)
    {
        // By not calling await you tell the code that you don't need this
        // calling method to await a return value.
        Task.Run(LongTask); 
    }
    
    private async Task LongTask()
    {
        while (true) { } // Thread should hung here
    }
