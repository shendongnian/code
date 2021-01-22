     private void listBox1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            Point p = new Point(e.X, e.Y);
            listBox1.SelectedIndex = listBox1.IndexFromPoint(p);
            contextMenuStrip1.Show();
        }
    }
