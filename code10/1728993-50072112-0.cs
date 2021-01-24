    public Main()
    {
        // other startup tasks here
        this.FormClosing += Main_FormClosing;
    }
    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
        var dialogResult = MessageBox.Show("Do you really want to quit?", "Exit", MessageBoxButtons.YesNo); 
        if (dialogResult == DialogResult.No)
        {
            e.Cancel = true;
            return;
        }
        Application.Exit();
    }
