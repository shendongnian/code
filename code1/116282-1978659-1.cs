    public Form1 f1;
    private void button1_Click(object sender, EventArgs e)
    {
        if (f1 == null)
        {
            f1 = new Form1 {f = this};
            f1.Show();
        }
        else
            f1.Focus();
    }
