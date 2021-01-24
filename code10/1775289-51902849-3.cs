    ToolTip tTip = new ToolTip();
    tTip.IsBalloon = true;
    tTip.ToolTipIcon = ToolTipIcon.Error;
    tTip.ToolTipTitle = "Your title";
    Point p;
    if (GetCaretPos(out p))
    {
        // This is optional. Removing it causes the arrow to point at the top of the line.
        int yOffset = textBox1.Font.Height;
        p.Y += yOffset;
        // Calling .Show() two times because of a known bug in the ToolTip control.
        // See: https://stackoverflow.com/a/4646021/4934172
        tTip.Show(string.Empty, textBox1, 0);
        tTip.Show("Your message here", textBox1, p, 1000);
    }
