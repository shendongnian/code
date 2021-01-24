    public byte[] ConvertToByteArray(string s)
    {
        IEnumerable<string> query = Enumerable.Empty<string>();
        
        if (s.StartsWith("0x"))
        {        
            // omit the 0x
            query = s.Skip(2)
            // get the char and index, so we can pair them up
                     .Select((c, i) => new { Char = c, Index = i })
            // group them into pairs
                     .GroupBy(o => o.Index / 2)
            // select them as new strings, so they can be converted
                     .Select(g => new string(g.Select(o => o.Char).ToArray()));
        }
        else
        {
            query = s.Split('-');
        }
        
        return query.Select(b => Convert.ToByte(b, 16)).ToArray();
    }
