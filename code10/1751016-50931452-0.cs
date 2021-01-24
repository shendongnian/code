    public Form1()
    {
      InitializeComponent();
      us11.btnDisplay.Click += BtnDisplay_Click;
    }
    private void us11_DisplayButtonClicked(object sender, EventArgs e)
    {
      us21.BringToFront();
    }
