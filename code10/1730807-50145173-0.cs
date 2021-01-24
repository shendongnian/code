    public Position getXY(string sym)
    {
        var lines = _draw.GetBackground();
        // lines.Length assumes a lines is a string[]
        for (int y = 0; y < lines.Length; y++)
        { 
            var matchIndex = lines[y].IndexOf(sym);
            // If the index is > -1, we found a  match
            if (matchIndex > -1)
            {
                return new Position(matchIndex, y);
            }
        }
        // It was not found, so return something that indicates that...
        return null;
    }
