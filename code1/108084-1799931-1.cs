    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            MessageBox.Show("Escape key pressed");
            // prevent child controls from handling this event as well
            e.SuppressKeyPress = true;
        }
    }
