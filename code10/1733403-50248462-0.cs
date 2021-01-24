    private void button2_click(object sender, System.EventArgs e)
    {
        if (MessageBox.Show("You will leave userControl1. Continue?", "Confirmation", 
                 MessageBoxButtons.OKCancel) == DialogResult.OK))
        {
            //Show userControl2
        }
    }
