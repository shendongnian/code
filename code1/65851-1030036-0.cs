    string input = "[section1 key1=value1 key2=value2][section2 key1=value1 key2=value2 key3=value3][section3 key1=value1]";
    MatchCollection matches = Regex.Matches(input, @"\[
                                                        (?<sectionName>\S+)
                                                          (\s+                                                            
                                                             (?<key>[^=]+)
                                                              =
                                                             (?<value>[^ \] ]+)                                                    
                                                          )+
                                                      ]", RegexOptions.IgnorePatternWhitespace);
        
    foreach(Match currentMatch in matches)
    {
        Console.WriteLine("Section: {0}", currentMatch.Groups["sectionName"].Value);
        CaptureCollection keys = currentMatch.Groups["key"].Captures;
        CaptureCollection values = currentMatch.Groups["value"].Captures;
        for(int i = 0; i < keys.Count; i++)
        {
            Console.WriteLine("{0}={1}", keys[i].Value, values[i].Value);           
        }
    }
