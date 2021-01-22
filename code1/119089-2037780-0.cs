    string str = phrase.ToLower();  //optional
    str = str.Trim();
    str = Regex.Replace(str, @"[^a-z0-9\s_]", ""); // invalid chars        
    str = Regex.Replace(str, @"\s+", " ").Trim(); // convert multiple spaces into one space
    str = str.Substring(0, str.Length <= 400 ? str.Length : 400).Trim(); // cut and trim it
    str = Regex.Replace(str, @"\s", "-");
