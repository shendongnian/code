    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    public Main_Form()
    {
        InitializeComponent();
        timer.Interval = 1000;
        timer.Tick += timer_Tick;
        timer.Start();
    }
    void timer_Tick(object sender, EventArgs e) {
      CircularTime.Text = DateTime.Now.ToString("hh:mm:ss");
      CircularTime.SubscriptText = DateTime.Now.ToString("tt");
    }
