      private void Form1_Paint(object sender, PaintEventArgs e)
        {
            RectangleControl rect1 = new RectangleControl() { Parent = this, Left = 20, Top = 20, Width = 250, Height = 250 };
            rect1.FillRectangle(Color.DeepSkyBlue);
            RectangleControl rect2 = new RectangleControl() { Parent = rect1, Left = 50, Top = 50, Width = 150, Height = 150 };
            rect2.FillRectangle(Color.LightBlue);
            rect1.MouseHover += Rect1_MouseHover;
            rect2.MouseLeave += Rect2_MouseLeave;
        }
        private void Rect2_MouseLeave(object sender, EventArgs e)
        {
            (sender as RectangleControl).BackColor = Color.Yellow;
        }
        private void Rect1_MouseHover(object sender, EventArgs e)
        {
            (sender as RectangleControl).BackColor = Color.LightBlue;
        }
