    for (int c = 0; c < curves.Count; c++)
    {
        e.Graphics.TranslateTransform(-curves[c].Item1.Width / 2, -curves[c].Item1.Height / 2);
        foreach (var p in curves[c].Item2)
            e.Graphics.DrawImage(curves[c].Item1, p);
        e.Graphics.ResetTransform();
    }
    if (curCurve != null && curCurve.Item2.Count > 0)
    {
        e.Graphics.TranslateTransform(-curCurve.Item1.Width / 2, -curCurve.Item1.Height / 2);
        foreach (var p in curCurve.Item2)
            e.Graphics.DrawImage(curCurve.Item1, p);
        e.Graphics.ResetTransform();
    }
