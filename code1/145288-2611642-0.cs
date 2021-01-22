    private Bitmap buffer = new Bitmap(this.Width, this.Height);
    private void button1_Click(object sender, EventArgs e)
    {
        // Draw into the buffer when button is clicked
        using (Graphics bufferGrph = Graphics.FromImage(buffer))
        {
            bufferGrph.DrawRectangle(new Pen(Color.Blue, 1), 1, 1, 100, 100);
        }
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        // Draw the buffer into the panel
        e.Graphics.DrawImageUnscaledAndClipped(buffer, 
                new Rectangle(new Point(0, 0), this.Size));
    }
