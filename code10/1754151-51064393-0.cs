    private void Form1_Load(object sender, EventArgs e)
    {
        textBox1.Text = Properties.Settings.Default.Test;
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        Properties.Settings.Default.Test = textBox1.Text;
        Properties.Settings.Default.Save();
    }
