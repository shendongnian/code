    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        //
        // Detect the KeyEventArg's key enumerated constant.
        //
        if (e.KeyCode == Keys.Enter)
        {
            MessageBox.Show("You pressed enter! Good job!");
        }
    }
