    Transform rotation = new RotateTransform { Angle = 30 };
    double max = path.Width + path.Height;
    double current = 0;
    for(double delta = max/2; delta > 0.25; delta = delta/2)
    {
      var line = new LineGeometry(
                      new Point(centerX + current, centerY),
                      new Point(centerX + max, centerY),
                      rotation);
      if(path.Data.FillContains(line))
        current += delta;
    }
    var intersectPoint = rotation.Transform(new Point(current, 0));
