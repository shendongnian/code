    public class Form1 : Form
    {
        private Bitmap buffer;
        public Form1()
        {
            InitializeComponent();
            // Initialize buffer
            panel1_Resize(this, null);
        }
        private void panel1_Resize(object sender, EventArgs e)
        {
            // Resize the buffer, if it is growing
            if (buffer == null || 
                buffer.Width < panel1.Width || 
                buffer.Height < panel1.Height)
            {
                Bitmap newBuffer = new Bitmap(panel1.Width, panel1.Height);
                if (buffer != null)
                    using (Graphics bufferGrph = Graphics.FromImage(newBuffer))
                        bufferGrph.DrawImageUnscaled(buffer, Point.Empty);
                buffer = newBuffer;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Draw the buffer into the panel
            e.Graphics.DrawImageUnscaled(buffer, Point.Empty);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Draw into the buffer when button is clicked
            PaintBlueRectangle();
        }
        private void PaintBlueRectangle()
        {
            // Draw blue rectangle into the buffer
            using (Graphics bufferGrph = Graphics.FromImage(buffer))
            {
                bufferGrph.DrawRectangle(new Pen(Color.Blue, 1), 1, 1, 100, 100);
            }
            // Invalidate the panel. This will lead to a call of 'panel1_Paint'
            panel1.Invalidate();
        }
    }
