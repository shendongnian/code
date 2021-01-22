    public MyMainForm( )
    {
        InitializeComponents();
        myUserControl.Load += new System.EventHandler(myUserControl_Load);
    }
    
    void myUserControl_Load(object sender, EventArgs e)
    {
        MessageBox.Show(((UserControl)sender).Name + " is loaded.");
    }
