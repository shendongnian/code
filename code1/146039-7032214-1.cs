    string text = @"<link href=""/_layouts/OracleBI/OracleBridge.ashx?RedirectURL=res/sk_oracle10/b_mozilla_4/common.css"" type=""text/css"" rel=""stylesheet""></link></link>"; 
    string pattern = @"(<link).+(link>)"; 
    //Regex myRegex = new Regex(pattern, RegexOptions.IgnoreCase); 
    //Match m = myRegex.Match(text);   // m is the first match
    Match m = Regex.Match(text, pattern, RegexOptions.IgnoreCase);
    /*while (m.Success)         
    {             
        // Do something with m             
        Console.Write(m.Value + "\n");             
        m = m.NextMatch();              // more matches         
    }*/
    // use if statement; you only need 1st match
    if (m.Success)
    {
        // Do something with m.Value
        // m.Index indicates its starting location in text
        // m.Length is the length of m.Value
        // using m.Index and m.Length allows for easy string replacement and manipulation of text
    }
    Console.Read();
