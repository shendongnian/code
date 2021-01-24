    var result = sites.Select(s => s.Split(','))
                      .Where(s => s.Length > 2)
                      .Select(s => s[2].Replace("test=", ""))
                      .ToDictionary(s => s,
                            s => GetTestCodeename(s,
                                     GetTestCode(s.IndexOf('_') != -1 ?
                                            s.Split('_')[1] : string.Empty)));  
