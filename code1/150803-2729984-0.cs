        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(
                new Pen(Color.Red,2f), 
                new Point(0,0), 
                new Point(pictureBox1.Size.Width, pictureBox1.Size.Height ));
            e.Graphics.DrawEllipse(
                new Pen(Color.Red, 2f),
                0,0, pictureBox1.Size.Width, pictureBox1.Size.Height  );
        }
