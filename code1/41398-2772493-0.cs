    protected enum enumParseState : int { StartToken, InQuote, InToken };
    public static List<String> ManuallyParseCommandLine()
    {
        String CommandLineArgs = Environment.CommandLine.ToString();
        
        Console.WriteLine("Command entered: " + CommandLineArgs);
        List<String> listArgs = new List<String>();
        
        Regex rWhiteSpace = new Regex("[\\s]");
        StringBuilder token = new StringBuilder();
        enumParseState eps = enumParseState.StartToken;
        
        for (int i = 0; i < CommandLineArgs.Length; i++)
        {
            char c = CommandLineArgs[i];
        //    Console.WriteLine(c.ToString()  + ", " + eps);
            //Looking for beginning of next token
            if (eps == enumParseState.StartToken)
            {
                if (rWhiteSpace.IsMatch(c.ToString()))
                {
                    //Skip whitespace
                }
                else
                {
                    token.Append(c);
                    eps = enumParseState.InToken;
                }
            }
            else if (eps == enumParseState.InToken)
            {
                if (rWhiteSpace.IsMatch(c.ToString()))
                {
                    Console.WriteLine("Token: [" + token.ToString() + "]");
                    listArgs.Add(token.ToString().Trim());
                    eps = enumParseState.StartToken;
                    
                    //Start new token.
                    token.Remove(0, token.Length);
                }
                else if (c == '"')
                {
                   // token.Append(c);
                    eps = enumParseState.InQuote;
                }
                else
                {
                    token.Append(c);
                    eps = enumParseState.InToken;
                }
            }
                //When in a quote, white space is included in the token
            else if (eps == enumParseState.InQuote)
            {
                if (c == '"')
                {
                   // token.Append(c);
                    eps = enumParseState.InToken;
                }
                else
                {
                    token.Append(c);
                    eps = enumParseState.InQuote;
                }
            }
            
        }
        if (token.ToString() != "")
        {
            listArgs.Add(token.ToString());
            Console.WriteLine("Final Token: " + token.ToString());
        }
        return listArgs;
    }
