    if ((stream = File.OpenFile()) != null)
    {
        using (StreamReader reader = new StreamReader(stream))
        {
            string patternstart = Regex.Escape("[[");
            string patternend = Regex.Escape("]]");
            string pattern = patternstart + @"(.*?)" + patternend;
            var tempdata = reader.ReadToEnd();
            str = Regex.Matches(tempdata, pattern).Cast<Match>().Select(m => m.Groups[1].Value).ToList();
        }
    }
