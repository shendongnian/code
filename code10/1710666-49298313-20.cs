    if (e.Button == MouseButtons.Left)
    {
        curCurve.Item2.Add(e.Location);
        panel1.Invalidate();
    }
