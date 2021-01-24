    var regexDictionary = Regex.Matches(    File.ReadAllText(path)
                                    , "(?<key>.+):(?<value>.+)")
                          .OfType<Match>()
                          .Where(m => m.Success)
                          .ToDictionary(m => m.Groups["key"].Value.Trim(),
                                        m => m.Groups["value"].Value.Trim());
                                        
    var ObjList = File.ReadAllLines(path)
                         .Select(line => line.Split(';'))
                         .Select(x => new MyObject { 
                            prop1 = x[0],
                            prop2 = x[1]
                            // etc 
                          })
                          
    var linQDictionary = File.ReadAllLines(path)
                             .Select(line => line.Split(';'))
                             .ToDictionary(
                                 c => x[0],
                                 c => x[1]
                             );
