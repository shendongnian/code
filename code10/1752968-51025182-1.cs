    
    public (int line, int column) GetLocation(string value, int position)
    {
        var line = 1;
        var column = position + 1;
    
        var matches = new Regex("\r\n?|\n").Matches(value);
        for (var i = 0; i < matches.Count; i++)
        {
            var match = matches[i];
            if (match.Index >= position)
            {
                break;
            }
    
            line += 1;
            column = position + 1 - (match.Index + match.Length);
        }
    
        return (line, column);
    }
