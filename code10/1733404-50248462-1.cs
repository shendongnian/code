    private void button2_click(object sender, System.EventArgs e)
    {
        if (MessageBox.Show("Show userControl2?", "Confirmation", 
                 MessageBoxButtons.YesNo) == DialogResult.Yes))
        {
            userControl2.BringToFront();
        }
    }
