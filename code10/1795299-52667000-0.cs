    private void ColourCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (ColourCheckBox.Checked)
        {
            ColourCheckBox.ForeColor = Color.Black;
        }
        else
        {
            ColourCheckBox.ForeColor = Color.Red;
        }
    }
