    public Form1()
    {
        InitializeComponent();
        Hide(); // Also Visible = false can be used
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        Thread.Sleep(10000);
        Show(); // Or visible = true;
    }
