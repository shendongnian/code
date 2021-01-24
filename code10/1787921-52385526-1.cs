    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        using (var bitmap = new Bitmap(1, 1))
        {
            var graphics = Graphics.FromImage(bitmap);
            var position = PointToScreen(e.Location);
            graphics.CopyFromScreen(position.X, position.Y, 0, 0, new Size(1, 1));
            var color = bitmap.GetPixel(0, 0);
            label1.Text = color.ToString();
        }
    }
