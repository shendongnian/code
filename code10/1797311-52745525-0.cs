    using (StringFormat sf = new StringFormat())
    {
        sf.Alignment = StringAlignment.Center;
        sf.LineAlignment = StringAlignment.Center;
        Graphics.DrawString($"s{i + 1}", panel.Font, new SolidBrush(Color.White),
                            pointOnCircle.X, pointOnCircle.Y, sf);
    }
