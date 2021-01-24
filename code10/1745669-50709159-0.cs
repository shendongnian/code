    private void txtRed_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Tab)
        {         
            txtRed.BackColor = System.Drawing.Color.Red;
            txtYellow.BackColor = System.Drawing.Color.DarkGray;
            txtGreen.BackColor = System.Drawing.Color.DarkGray;
        }
    }
