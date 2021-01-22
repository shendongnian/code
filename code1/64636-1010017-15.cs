    string InsertNewLines(string s, int interval)
    {
        char[] buf = new char[s.Length + (int)Math.Ceiling(s.Length / (double)interval)];
    
        using (var rdr = new StringReader(s))
        {
            for (int i=0; i<buf.Length-interval; i++)
            {
                rdr.ReadBlock(buf, i, interval);
                i+=interval;
                buf[i] = '\n';
            }
            if (i < s.Length)
            {
                rdr.ReadBlock(buf, i, s.Length - i);
                buf[buf.Length - 1] = '\n';
            }
        }
        return new string(buf);
    }
    
