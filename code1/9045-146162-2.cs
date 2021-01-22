    string illegal = "\"M\"\\a/ry/ h**ad:>> a\\/:*?\"| li*tt|le|| la\"mb.?";
    string regexSearch = string.Format("{0}{1}",
                         new string(Path.GetInvalidFileNameChars()), 
                         new string(Path.GetInvalidPathChars()));
    Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch));
    illegal = r.Replace(illegal, "");
