    public Form1()
    {
        InitializeComponent();
        Timer2.Tick += new EventHandler(Timer2_Tick);
        Timer2.Interval = 3000;
    }
    
    Timer Timer2;
    
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        Timer2.Enabled = true;
    }
    
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        Timer2.Enabled = false;
    }
    
    void Timer2_Tick(object sender, EventArgs e)
    {
        FontSizeControl.Show();
        Timer2.Enabled = false;
    }
