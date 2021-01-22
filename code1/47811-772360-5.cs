    private void image_MouseMove(object sender, MouseEventArgs e)
    {
        if (image.IsMouseCaptured)
        {
            var tt = (TranslateTransform)((TransformGroup)image.RenderTransform)
                .Children.First(tr => tr is TranslateTransform);
            Vector v = start - e.GetPosition(border);
            tt.X = origin.X - v.X;
            tt.Y = origin.Y - v.Y;
        }
    }
