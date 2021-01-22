    private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        // Determine whether the keystroke is the down arrow.
        if (e.KeyCode == Keys.Down)
        {
            charMode = !charMode;
        }
    }
