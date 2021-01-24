    private void button14_Click(object sender, EventArgs e)
    {
        var cdlg = new ColorDialog();
        if (cdlg.ShowDialog() == DialogResult.OK)
        {
            button14.BackColor = cdlg.Color;
        }
    }
