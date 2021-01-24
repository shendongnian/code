    Color c = Color.Black;
    switch (s) {
        case Status.Error: c = Color.DarkRed; break;
        case Status.Warning: c = Color.DarkGoldenrod; break;
        case Status.Success: c = Color.DarkGreen; break;
    }
    rtb.Select(rtb.TextLength, 0);
    rtb.SelectionColor = c;
    rtb.AppendText($"{e.Message}\n");
    rtb.ScrollToCaret();
