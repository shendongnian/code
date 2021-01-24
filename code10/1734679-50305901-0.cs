    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        char ch = e.KeyChar; // Getting the Key that was pressed
        if (ch == 13) // Checking if it equal to 13 ASCII code for return 
        {
            if (int.Parse(textBox1.Text) < 8)
            {
                textBox1.Text = ""; // emptying the textbox
                textBox1.AppendText("8"); // using AppendText() to keep the cursor at the end
            }
            else if (int.Parse(textBox1.Text) > 32)
            {
                textBox1.Text = "";
                textBox1.AppendText("32");
            }
            e.Handled = true; // To say that the event was handled.
        }
    }
