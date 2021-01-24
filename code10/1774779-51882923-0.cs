    // test string with some whitespace and a control char in the end of the string
    string beats = "STA27,STA27,STA27B,STA27A,STA27B,   " + '\u0002'; 
    beats = string.Join(string.Empty, beats.ToCharArray().Where(x => !Char.IsControl(x) && !Char.IsWhiteSpace(x)));
    List<string> distinctBeats = beats.Split(",", StringSplitOptions.RemoveEmptyEntries)
                                      .Distinct()
                                      .ToList();
