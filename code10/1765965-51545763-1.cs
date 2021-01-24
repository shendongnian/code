    UpdateStatus s = e.Status;
    Color textColor = Color.Black;
    switch (selections[selection]) {
        case Status.Error: textColor = Color.DarkRed; break;
        case Status.Warning: textColor = Color.DarkGoldenrod; break;
        case Status.Success: textColor = Color.DarkGreen; break;
    }
    rtb.Select(rtb.TextLength, 0);
    rtb.SelectionColor = textColor;
    rtb.AppendText($"{e.Message}\n");
    rtb.ScrollToCaret();
