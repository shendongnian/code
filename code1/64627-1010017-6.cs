    string InsertNewLines(string s, int interval)
    {
        string[] buf = new string[s.Length + Math.Ceiling(s.Length / (double)interval)];
    
        using (var rdr = new StringReader(s))
        {
            for (int i=0; i<s.Length; i++)
            {
                rdr.ReadBlock(buf, i, interval);
                i+=len;
                buf[i] = '\n';
            }
        }
        return new string(buf);
    }
    
