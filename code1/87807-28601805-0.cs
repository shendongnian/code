    public static class StringExtensions
    {
        // the string.Split() method from .NET tend to run out of memory on 80 Mb strings. 
        // this has been reported several places online. 
        // This version is fast and memory efficient and return no empty lines. 
        public static List<string> LowMemSplit(this string s, string seperator)
        {
            List<string> list = new List<string>();
            int lastPos = 0;
            int pos = s.IndexOf(seperator);
            while (pos > -1)
            {
                while(pos == lastPos)
                {
                    lastPos += seperator.Length;
                    pos = s.IndexOf(seperator, lastPos);
                    if (pos == -1)
                        return list;
                }
                string tmp = s.Substring(lastPos, pos - lastPos);
                if(tmp.Trim().Length > 0)
                    list.Add(tmp);
                lastPos = pos + seperator.Length;
                pos = s.IndexOf(seperator, lastPos);
            }
            if (lastPos < s.Length)
            {
                string tmp = s.Substring(lastPos, s.Length - lastPos);
                if (tmp.Trim().Length > 0)
                    list.Add(tmp);
            }
            return list;
        }
    }
