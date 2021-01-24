    e.Graphics.DrawLine(pen1, 0, 40, 600, 40);  // black line
    float scale = 2.5f;
    e.Graphics.ResetTransform();
    e.Graphics.ScaleTransform(scale, scale);
    pen2.DashPattern = pen2.DashPattern.Select(x => x / scale).ToArray();
    e.Graphics.DrawLine(pen2, 0, 30, 600, 30);  // pink line
