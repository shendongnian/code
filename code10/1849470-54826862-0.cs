    public SampleForm()
    {
        InitializeComponent();
        label1.text = "0";
        StartDate = DateTime.Now;
    }
    DateTime StartDate;
    private void trackBar_ValueChanged(object sender, EventArgs e)
    {
       label1.Text = StartDate.AddDays(trackbar.Value).ToShortDateString();
    }
