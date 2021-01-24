    public DateTime LastDeactivate { get; set; } = DateTime.Now;
    private void Form1_Deactivate(object sender, EventArgs e)
    {
        this.Hide();
        LastDeactivate = DateTime.Now;
    }
