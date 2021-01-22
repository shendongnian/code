    string inputSample = "[Name Parameter=\"SomeWord\", p=\"hello world\"       a=b,c=4 P1=\"2\"]";
    var m = Regex.Match(inputSample, @"\[
                                            \s*(?<name>\w+)\s*                         # capture the name
                                            (?<parameter>                              # start the parameters
                                                [\s,]*                                 # allow whitespace before a parameter
                                                    (?<paramName>\w+)                  # capture the parameter name
                                                    \s*                                # allow whitespace after a name
                                                    =                                  
                                                    \s*                                # allow whitespace before a value
                                                    (                                  # a value can either be:
                                                        (?<paramValue>\w+)             # one whole word 
                                                        |                              # or
                                                        (""(?<paramValue>[^""]*)"")    # a quoted string
                                                    )
                                            )*
                                       \]", RegexOptions.IgnorePatternWhitespace);
    
    if(m.Success)
    {
        string name = m.Groups["name"].Value;
        Dictionary<string, string> parameters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        int count = m.Groups["parameter"].Captures.Count;
        for(int i = 0; i < count; i++)
        {
            parameters[m.Groups["paramName"].Captures[i].Value] = m.Groups["paramValue"].Captures[i].Value;
        }
    
        string pValue = parameters["p"];
    }
