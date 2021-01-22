    class Form1 : Form
    {
        // ...
        Image i = new Bitmap(@"C:\Users\jasond\Pictures\foo.bmp");
        Point lastLocation = Point.Empty;
        Size delta = Size.Empty;
        Point drawLocation = Point.Empty;
        bool dragging = false;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!dragging)
                {
                    lastLocation = e.Location;
                    dragging = true;
                }
                delta = new Size(lastLocation.X - e.Location.X, lastLocation.Y - e.Location.Y);
                lastLocation = e.Location;
                if (!delta.IsEmpty)
                {
                    drawLocation.X += delta.Width;
                    drawLocation.Y += delta.Height;
                    pictureBox1.Invalidate();
                }
            }
            else
            {
                dragging = false;
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle source = new Rectangle(drawLocation,pictureBox1.ClientRectangle.Size);
            e.Graphics.DrawImage(i,pictureBox1.ClientRectangle,source, GraphicsUnit.Pixel);
        }
        //...
