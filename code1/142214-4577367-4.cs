    public SystemTrayApp()
    {
        InitializeComponent();
        this.Visible = false;
        // Hide Maximize and Minimize buttons on form
        this.StartPosition = FormStartPosition.CenterScreen;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
    }
