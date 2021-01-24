    RotateTransform rotateTransform = new RotateTransform();
    image.LayoutTransform = rotateTransform;
    rotateTransform.BeginAnimation(RotateTransform.AngleProperty,
        new DoubleAnimation() { From = 0, To = 360, Duration = TimeSpan.FromSeconds(1), RepeatBehavior = RepeatBehavior.Forever, FillBehavior = FillBehavior.Stop });
    await Task.Run(...);
    rotateTransform.BeginAnimation(RotateTransform.AngleProperty, null);
