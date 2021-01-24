        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            Pen p = new Pen(Color.Red, 3);
            var cursorPosition = pictureBox1.PointToClient(Cursor.Position);
            g.DrawEllipse(p, cursorPosition.X, cursorPosition.Y, 15, 15);
            MyCircles.Add(cursorPosition);
            pictureBox1.Refresh();
        }
        List<Point> MyCircles = new List<Point>();
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            foreach (var item in MyCircles)
            {
                MessageBox.Show($"One circle was created: X:{item.X}, Y:{item.Y}");
            }
        }
