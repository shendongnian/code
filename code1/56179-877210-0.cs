    ToolTip tip = new ToolTip();
    private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
    {
        Cursor a = System.Windows.Forms.Cursor.Current;
        if (a == Cursors.Hand)
        {
            Point p = richTextBox1.Location;
            tip.Show(
                GetWord(richTextBox1.Text,
                    richTextBox1.GetCharIndexFromPosition(e.Location)),
                this,
                p.X + e.X,
                p.Y + e.Y + 32,
                1000);
        }
    }
