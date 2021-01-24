        if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
        {
            displayText("0");
        }
        if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
        {
            displayText("1");
        }
        private void displayText(string digit)
        {
            if (printer.Text == "0")
                printer.Text = digit;
            else
                printer.Text += digit;
        }
