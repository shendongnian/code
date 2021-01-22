    public Window1()
    {
        InitializeComponent();    
        this.Deactivated += new EventHandler(Window1_Deactivated);
    }
        
    void Window1_Deactivated(object sender, EventArgs e)
    {
        Visibility = Visibility.Collapsed;
    }
