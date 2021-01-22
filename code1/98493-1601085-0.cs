    public MainPage()
    {
        InitializeComponent();
    
        string badText = "I wonder if the filter will filter this out: shit bad luck";
        ServiceReference1.ProfanitySoapClient client = new ServiceReference1.ProfanitySoapClient();
        client.ProfanityFilterCompleted += new EventHandler<ServiceReference1.ProfanityFilterCompletedEventArgs>(client_ProfanityFilterCompleted);
        client.ProfanityFilterAsync(badText, 0, false);            
    }
    
    void client_ProfanityFilterCompleted(object sender, ServiceReference1.ProfanityFilterCompletedEventArgs e)
    {
        string cleanText = e.Result.CleanText;  // Web service callback is here
    }
