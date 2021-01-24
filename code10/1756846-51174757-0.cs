    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left) {
            bmp.SetPixel(e.Location.X, e.Location.Y, Color.Green);
            bmp.SetPixel((e.Location.X) + 1, e.Location.Y, Color.Green);
            bmp.SetPixel((e.Location.X) - 1, e.Location.Y, Color.Green);
            bmp.SetPixel(e.Location.X, (e.Location.Y) + 1, Color.Green);
            bmp.SetPixel(e.Location.X, (e.Location.Y) - 1, Color.Green);
            panel1.Invalidate(
                new Rectangle(e.Location.X - 1, e.Location.Y - 1, 3, 3));
        }
    }
