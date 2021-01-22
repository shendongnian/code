        private Point rtfLocation;
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Right)
            {
                rtfLocation = this.PointToClient(textBox1.PointToScreen(new Point(e.X, e.Y)));
                textBox1.ShortcutsEnabled = false;
                richTextBox1.Location = rtfLocation;
                richTextBox1.Show();
            }
        }
        private void richTextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            richTextBox1.Hide();
        }
        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            richTextBox1.Hide();
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Visible)
            {
                richTextBox1.Hide();
            }
        }
        private void richTextBox1_VisibleChanged(object sender, EventArgs e)
        {
            textBox1.ShortcutsEnabled = ! richTextBox1.Visible;
        }
