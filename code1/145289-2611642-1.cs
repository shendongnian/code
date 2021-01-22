    public class Form1 : Form
    {
        private Bitmap buffer;
        public Form1()
        {
            // Create a new buffer image
            buffer = new Bitmap(panel1.Width, panel1.Height)
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Draw into the buffer when button is clicked
            using (Graphics bufferGrph = Graphics.FromImage(buffer))
            {
                bufferGrph.DrawRectangle(new Pen(Color.Blue, 1), 1, 1, 100, 100);
            }
            // Redraw the form. This will lead to a call of 'panel1_Paint'
            this.Refresh();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Draw the buffer into the panel
            e.Graphics.DrawImageUnscaledAndClipped(buffer, 
                    new Rectangle(new Point(0, 0), buffer.Size));
        }
    }
