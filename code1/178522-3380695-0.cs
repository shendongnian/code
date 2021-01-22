    public Form1()
    {
        InitializeComponent();
        this.FormClosing += Form1_FormClosing;
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        DialogResult result = MessageBox.Show("Really close this form?", string.Empty, MessageBoxButtons.YesNo);
        if (result == DialogResult.No)
        {
            e.Cancel = true;
        }
    }
