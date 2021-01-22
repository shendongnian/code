    private void image_MouseMove(object sender, MouseEventArgs e)
    {
        if (image.IsMouseCaptured)
        {
            Vector v = start - e.GetPosition(image);
            double deltax = v.X / image.ActualWidth;
            double deltay = v.Y / image.ActualHeight;
            image.RenderTransformOrigin = new Point(origin.X + deltax, origin.Y + deltay);
        }
    }
