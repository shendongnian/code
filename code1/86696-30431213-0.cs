    public FormProgress()
    {
        InitializeComponent();
        Rectangle r = Screen.PrimaryScreen.WorkingArea;
        this.StartPosition = FormStartPosition.Manual;
        this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
    }
