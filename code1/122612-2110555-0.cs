    string FileName = "File name and path";
    FileStream FS = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
    StreamReader SR = new StreamReader(FS);
    string input = null;
    string Text = string.Empty;
    while ((input = SR.ReadLine()) != null) { Text += input; }
    Regex RegPattern = new Regex("foo");
    Match Match = RegPattern.Match(Text);
    string value = Match.ToString();
