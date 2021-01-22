    public Form1()
    {
        InitializeComponent();
        Timer1.Tick += new EventHandler(Timer1_Tick);
    }
    
    Timer Timer1;
    
    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        // Will need handling to ensure it's not already displaying, etc... then:
        FontSizeControl.Show();
        Timer1.Enabled = true;
    }
    
    private void FontSizeControl_FontSizeChanged(object sender, EventArgs e)
    {
    
        // Change the font size
        ...
    
        // Reset the timer
        Timer1.Enabled = false;
        Timer1.Enabled = true;
    
    }
    
    void Timer1_Tick(object sender, EventArgs e)
    {
        FontSizeControl.Hide();
        Timer1.Enabled = false;
    }
