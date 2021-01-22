    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control & e.KeyCode == Keys.C)
        {
            MessageBox.Show( "Ctrl + C pressed" );
            // Swallow key event, i.e. indicate that it was handled.
            e.Handled = true;
        }
    }
