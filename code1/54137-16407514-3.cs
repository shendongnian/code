    private void form1_load(object sender, EventArgs e)
    {
        btnTest.Enabled = false;
    }
    private void btnStart_Click(object sender, EventArgs e)
    {
        btnTest.Enabled = false;
        btnTest_click(sender, e);
        btnTest_click(sender, e);
        btnTest_click(sender, e);
        btnTest.Enabled = true;
    }
    private int _count = 0;
    private void btnTest_click(object sender, EventArgs e)
    {
        _count++;
        label1.Text = _count.ToString();
    }
