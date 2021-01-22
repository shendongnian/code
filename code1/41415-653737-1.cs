    string abbr      = "memb";
    string word      = "Member";
    string pattern   = String.Format("\b{0}\b", Regex.Escape(abbr));
    string substitue = String.Format("[a title=\"{0}\"]{1}[/a]", word, abbr);
    string output    = Regex.Replace(input, pattern, substitue);
