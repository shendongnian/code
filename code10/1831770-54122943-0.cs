    private void Form2_VisibleChanged(object sender, EventArgs e)
    {
        foreach (string item in Savestate.number)
        {
            label1.Text += item;
        }
    }
