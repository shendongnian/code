    public void ConvertXLS(TextReader s)
    {
        var columnData = new List<string>();
        bool lastWasColumnData = false;
        bool seenAnyData = false;
        foreach (var token in GetTokens(s))
        {
            switch (token.Type)
            {
                case TokenType.ColumnData:
                {
                     seenAnyData = true;
                     if (lastWasColumnData)
                     {
                         //TODO: do some error reporting
                     }
                     else
                     {
                         lastWasColumnData = true;
                         columnData.Add(token.Data);
                     }
                     break;
                }
                case TokenType.Comma:
                {
                    if (!lastWasColumnData)
                    {
                        columnData.Add(null);
                    }
                    lastWasColumnData = false;
                    break;
                }
                case TokenType.LineTerminator:
                {
                    if (seenAnyData)
                    {
                        OutputLine(lastWasColumnData);
                    }
                    seenAnyData = false;
                    lastWasColumnData = false;
                    columnData.Clear();
                }
            }
        }
        if (seenAnyData)
        {
            OutputLine(columnData);
        }
    }
