    var totalRotationAngle = rand.NextDouble() * 3600;
    rotateTransform.BeginAnimation(RotateTransform.AngleProperty, new DoubleAnimation
    {
        By = totalRotationAngle,
        Duration = TimeSpan.FromMilliseconds(totalRotationAngle)
    });
