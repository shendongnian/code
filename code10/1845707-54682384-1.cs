    private void Form2_Load(object sender, EventArgs e)
    {
        checkBox1.Checked = Properties.Settings.Default.checkB;
        if (checkBox1.CheckState == CheckState.Checked)
        {
            Form1 f1 = (Form1)this.Owner;
            f1.button1.Visible = false; // or whatever your buttons are called
        }
    }
