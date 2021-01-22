    private MyControl mycontrol = new MyControl();
    private void MainForm()
    {
        this.Controls.Add(mycontrol);
    
        InitializeComponent();
    }
    
    private void DoStuff()
    {
        ((MyControl)mycontrol).MyMethod();
    }
