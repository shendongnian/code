    public void Draw(Shape vorm, Canvas canvas, Point locatie)
    {
        if (vorm.Height <= canvas.Height && vorm.Width <= canvas.Width)
        {
            Canvas.SetTop(vorm, locatie.Y);
            Canvas.SetLeft(vorm, locatie.X);
            canvas.Children.Add(vorm);
        }
    }
