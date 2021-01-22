    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        if (e.Control)
        {
            sb.Append(Keys.Control.ToString());
            sb.Append(" + ");
        }
        if (e.Alt)
        {
            sb.Append(Keys.Alt.ToString());
            sb.Append(" + ");
        }
        if (e.Shift)
        {
            sb.Append(Keys.Shift.ToString());
            sb.Append(" + ");
        }
        if (e.KeyCode != Keys.ShiftKey
            && e.KeyCode != Keys.ControlKey
            && e.KeyCode != Keys.Menu)
        {
            sb.Append(e.KeyCode.ToString());
        }
        textBox1.Text = sb.ToString();
    }
