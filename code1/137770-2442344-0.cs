        Graphics g = null; // initialize in Form_Load with this.CreateGraphics()
        Point lastPoint;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                g.DrawLine(Pens.Blue, lastPoint, e.Location);
                lastPoint = e.Location;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
        }
