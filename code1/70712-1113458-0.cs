    private void PictureBox_Paint(object sender, PaintEventArgs e)
    {
        int width = myPictureBox.ClientSize.Width / 2;
        int height = myPictureBox.ClientSize.Height / 2;
    
        Rectangle rect = new Rectangle(0, 0, width, height);
        e.Graphics.FillRectangle(Brushes.White, rect);
        rect = new Rectangle(width, 0, width, height);
        e.Graphics.FillRectangle(Brushes.Red, rect);
        rect = new Rectangle(0, height, width, height);
        e.Graphics.FillRectangle(Brushes.Green, rect);
        rect = new Rectangle(width, height, width, height);
        e.Graphics.FillRectangle(Brushes.Blue, rect);
    }
