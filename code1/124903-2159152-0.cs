    string input = @"
        Int NOT NULL
        Int
        VarChar(255)
        VarChar(255) NOT NULL
        Bit";
    foreach (Match m in Regex.Matches(input,
        @"^\s*(?<datatype>\w+)(?:\((?<length>\d+)\))?(?<nullable> (?:NOT )?NULL)?",
        RegexOptions.ECMAScript | RegexOptions.Multiline))
    {
        Console.WriteLine(m.Groups[0].Value.Trim());
        Console.WriteLine("\tdatatype: {0}", m.Groups["datatype"].Value);
        Console.WriteLine("\tlength  : {0}", m.Groups["length"  ].Value);
        Console.WriteLine("\tnullable: {0}", m.Groups["nullable"].Value);
    }
