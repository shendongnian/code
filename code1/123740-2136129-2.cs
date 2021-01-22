    string input = @"foo ( parens ) bar { braces } foo [ brackets ] bar. single ' quote & "" double "" quote.
    dash - test. Connector _ test. Comma, test. Semicolon; test. Colon: test. Slash / test. Slash \ test.";
    
    string[] patterns = { 
        @"(^|\p{P}\s+)(\w+)", // all punctuation chars
        @"(^|[\p{P}-[\p{Pc}\p{Pd}\p{Ps}\p{Pe}]]\s+)(\w+)", // all punctuation chars except Pc/Pd/Ps/Pe
    	@"(^|[\p{P}-[\p{Po}]]\s+)(\w+)" // all punctuation chars except Po
    };
    
    // compiled for performance (might want to benchmark it for your loop)
    foreach (string pattern in patterns)
    {
        Console.WriteLine("*** Current pattern: {0}", pattern);
        string result = Regex.Replace(input, pattern,
                                m => m.Groups[1].Value
                                     + m.Groups[2].Value.Substring(0, 1).ToUpper()
                                     + m.Groups[2].Value.Substring(1));
        Console.WriteLine(result);
        Console.WriteLine();
    }
