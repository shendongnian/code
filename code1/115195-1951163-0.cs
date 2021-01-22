    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Middle)
        {
            label1.Text = String.Format("{0} :: {1}", e.X, e.Y);
        }
    }
