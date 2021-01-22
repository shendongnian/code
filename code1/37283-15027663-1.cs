    IEnumerable<TokenInfo> ParseSql(string sql)
    {
        ParseOptions parseOptions = new ParseOptions();
        Scanner scanner = new Scanner(parseOptions);
        int state = 0,
            start,
            end,
            lastTokenEnd = -1,
            token;
        bool isPairMatch, isExecAutoParamHelp;
        List<TokenInfo> tokens = new List<TokenInfo>();
        scanner.SetSource(sql, 0);
        while ((token = scanner.GetNext(ref state, out start, out end, out isPairMatch, out isExecAutoParamHelp)) != (int)Tokens.EOF)
        {
            TokenInfo tokenInfo =
                new TokenInfo()
                {
                    Start = start,
                    End = end,
                    IsPairMatch = isPairMatch,
                    IsExecAutoParamHelp = isExecAutoParamHelp,
                    Sql = sql.Substring(start, end - start + 1),
                    Token = (Tokens)token,
                };
            tokens.Add(tokenInfo);
            lastTokenEnd = end;
        }
        return tokens;
    }
