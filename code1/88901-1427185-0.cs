    int count;
    
    using (StreamReader reader = File.OpenText("fileName")
    {
       string contents = reader.ReadToEnd();
       MatchCollection matches = Regex.Matches(contents, "you");
       count = matches.Count;
    }
