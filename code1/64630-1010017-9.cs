    string InsertNewLines(string s, int interval)
    {
        char[] buf = new char[s.Length + (int)Math.Ceiling(s.Length / (double)interval)];
    
        using (var rdr = new StringReader(s))
        {
            for (int i=0; i<s.Length; i++)
            {
                rdr.ReadBlock(buf, i, interval);
                i+=interval;
                buf[i] = '\n';
            }
        }
        return new string(buf);
    }
    
