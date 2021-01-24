    public  Form1()
    {
        InitializeComponent();
    }
    public async void OnButton1_Clicked(object sender, ...)
    {   // because this is an event handler the return value is void
        
        // Start the first test and await until ready
        await TestAsync();
        // Start the second test and await until ready:
        int i = await TestAsync(1);
    }
