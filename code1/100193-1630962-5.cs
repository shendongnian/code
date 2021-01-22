    // zero-width split:
    string[] linksWithText = Regex.Split(yourString, @"(?<=http:\S+-\d+/)");
    foreach (string link in linksWithText)
    {
        Match m = Regex.Match(link, @"(.*)(http:\S+-(\d+)/)$");
        if (m.Success)
        {
            string text = m.Groups[1].Value;
            string url = m.Groups[2].Value;
            string id = m.Groups[3].Value;
        }
    }
