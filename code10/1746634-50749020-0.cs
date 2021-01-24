    Form1 MainForm = new Form1();
    public Welcome_window()
    {
        InitializeComponent();
        timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        progressBar1.Increment(10);
        if (progressBar1.Value == 100)
        {
            timer1.Stop(); 
            this.Visible = false;                                      
            MainForm.ShowDialog();
            this.Close();                
        }
    }
