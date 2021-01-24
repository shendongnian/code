    public int sec;
    public int min;
    
    public Form1() //Constructor
    {
        InitializeComponent();
        sec = 0;
        min = 0;
        timer1.Start();
        myTimer.Tick += new EventHandler(timer1_Tick);
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        sec++; //Seconds increase
        if(sec==60)
        {
            sec = 0; //Reset Seconds
            min++; //Minutes increase
        }
        label9.Text = ("Timer: "+min+":"+sec); //Update the label
        Debug.WriteLine("Tick "+sec);
    }
