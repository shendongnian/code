    public void paintOnPictureBox()
            {
                Rectangle ee = new Rectangle(10, 10, 50, 50);
                Graphics gr = Graphics.FromImage(pictureBox1.Image);
                using (Pen pen = new Pen(Color.Green, 2))
                {
                    gr.DrawRectangle(pen, ee);
                }
    this.Refresh();
            }
