    public byte[] ConvertToByteArray(string s)
    {
        IEnumerable<string> query = Enumerable.Empty<string>();
        
        if (s.StartsWith("0x"))
        {
            query = IterateHexPairs(s.Substring(2));
        }
        else
        {
            query = s.Split('-');
        }
        
        return query.Select(b => Convert.ToByte(b, 16)).ToArray();
        
        IEnumerable<string> IterateHexPairs(string hexLiteral)
        {
            char? previousNibble = null;
            
            foreach (var nibble in hexLiteral)
            {
                if (previousNibble != null)
                {
                    yield return new string(new char[] { previousNibble.Value, nibble });
                    previousNibble = null;
                }
                else
                {
                    previousNibble = nibble;   
                }                               
            }
        }
    }
