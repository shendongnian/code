    using System.Text.RegularExpressions;
    string[] samples = {
        @"Hellotoevryone<img height=""115"" width=""150"" alt="""" src=""/Content/Edt/image/b4976875-8dfb-444c-8b32-cc b47b2d81e0.jpg"" />Iamsogladtoseeall.",
        "Testing123Hello.World",
        @"Test<a href=""http://stackoverflow.com"">StackOverflow</a>",
        @"Blah<a href=""http://stackoverflow.com"">StackOverflow</a>Blah<a href=""http://serverfault.com"">ServerFault</a>",
        @"Test<a href=""http://serverfault.com"">Server Fault</a>", // has a space, not matched
        "Stack Overflow" // has a space, not matched
    };
    
    // use these 2 lines if you don't want to use regex comments
    //string pattern = @"^((?:\S(?:\<[^>]+\>)?){1,10})+$";
    //Regex rx = new Regex(pattern);
    
    // regex comments spanning multiple lines requires use of RegexOptions.IgnorePatternWhitespace
    string pattern = @"^(               # match line/string start, begin group
                        (?:\S           # match (but don't capture) non-whitespace chars
                        (?:\<[^>]+\>)?  # optionally match (doesn't capture) an html <...> tag
                                        # to match img tags only change to (?:\<img[^>]+\>)?
                        ){1,10}         # match upto 10 chars (tags don't count per your example)
                        )+$             # match at least once, and match end of line/string
                        ";
    Regex rx = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
    
    foreach (string sample in samples)
    {
        if (rx.IsMatch(sample))
        {
            foreach (Match m in rx.Matches(sample))
            {
                // using group index 1, group 0 is the entire match which I'm not interested in
                foreach (Capture c in m.Groups[1].Captures)
                {
                    Console.WriteLine("Capture: {0} -- ({1})", c.Value, c.Value.Length);
                }
            }
        }
        else
        {
            Console.WriteLine("Not a match: {0}", sample);
        }
    
        Console.WriteLine();
    }
