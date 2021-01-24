    long ContentLength = 0;
    if (long.TryParse(resp.Headers.Get("Content-Length"), out ContentLength))
    {
        var size = AdjustFileSize(ContentLength);
        sizevaluelabel.Text = size.Item1.ToString("0.00");
        kbmbgb.Text = size.Item2;
    }
