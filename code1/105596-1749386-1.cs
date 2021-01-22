    Match m = Regex.Match(original, "^([0-9A-Za-z]*)(.*)$");
    string good = m.Groups[1].Value;
    string bad = m.Groups[2].Value;
    if (bad.Length > 0)
    {
        // log bad characters
    }
    Console.WriteLine(good);
