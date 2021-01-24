    private void txtConsoleIn_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode==Keys.Enter)
        {
            // Execute command - your code
            MessageBox.Show("Start()"); // this line just for test
        }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        txtConsoleIn.Text = "start()";
        txtConsoleIn.Focus();
        SendKeys.Send("{ENTER}");
    }
