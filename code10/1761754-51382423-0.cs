    var testString = @"a:ab2c:/b1c\xy";
    var reg = new Regex(@"(?:([a-z]+)(?:[a-z0-9:]*?))+/[a-z0-9]+\\([a-z]*)");
    var matches = reg.Matches(testString);
    foreach (Match match in matches)
    {
        var prefixGroup = match.Groups[1];
        var postfixGroup = match.Groups[2];
        foreach (Capture prefixCapture in prefixGroup.Captures)
        {
            for (int i = 0; i < prefixCapture.Length; i++)
            {
                for (int j = 0; j < postfixGroup.Length; j++)
                {
                    var start = prefixCapture.Index + i;
                    var end = postfixGroup.Index + postfixGroup.Length - j;
                    Console.WriteLine(testString.Substring(start, end - start));
                }
            }
        }
    }
