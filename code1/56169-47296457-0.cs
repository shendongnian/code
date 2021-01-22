    String donen = "lots of stupid whitespaces and new lines and others..."
    
    //Remove multilines
    donen = Regex.Replace(donen, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
    //remove multi whitespaces
    RegexOptions options = RegexOptions.None;
    Regex regex = new Regex("[ ]{2,}", options);
    donen = regex.Replace(donen, " ");
    //remove tabs
    char tab = '\u0009';
    donen = donen.Replace(tab.ToString(), "");
    //remove endoffile newlines
    donen = donen.TrimEnd('\r', '\n');
    //to be sure erase new lines again from another perspective
    donen.Replace(Environment.NewLine, "");
