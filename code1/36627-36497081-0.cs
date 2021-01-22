    public Form1()
    {
        InitializeComponent();
        Application.Idle += Application_Idle;
    }
    void Application_Idle(object sender, EventArgs e)
    {
        if (Control.IsKeyLocked(Keys.CapsLock))
            toolStripStatusLabel1.Text = "CapsLock is On";
        else
            toolStripStatusLabel1.Text = "";
    }
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        Application.Idle -= Application_Idle;
        base.OnFormClosed(e);
    }
