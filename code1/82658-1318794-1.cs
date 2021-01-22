    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.F1)
        {
            MessageBox.Show("Control + F1 key up");
        }
    }
