    Rectangle bounds = this.Bounds;
    using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
    {
        using (Graphics g = Graphics.FromImage(bitmap))
        {
            g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            Rectangle formScreenRect = RectangleToScreen(this.ClientRectangle);
            int offsetX = formScreenRect.Left - this.Left;
            int offsetY = formScreenRect.Top - this.Top;
            Rectangle textBoxRect = new Rectangle(textBox1.Left + offsetX, 
                                                  textBox1.Top + offsetY,
                                                  textBox1.Width, textBox1.Height);
            g.FillRectangle(Brushes.Black, textBoxRect);
        }
    }
