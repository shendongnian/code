    private void btn2_OnClick(object sender, RoutedEventArgs e)
    {
        string[] lines = txt.Text.Split(new char[] { '\n' });
        var sb = new StringBuilder();
        for (var i = 1; i < 7; i++)
            sb.AppendLine(lines[150 * i].Trim());
        for (var i = 1; i < 7; i++)
            sb.AppendLine(lines[15000 * i].Trim());
        txt.Text = sb.ToString();
    }
