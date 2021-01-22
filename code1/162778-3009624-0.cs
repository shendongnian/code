        static string[] Empty = new string [] {};
        static string[] SplitByLength(string str, int len)
        {
            Regex r = new Regex(string.Format("^(.{{1,{0}}})*$",len));
            Match m = r.Match(str);
            if(m.Groups.Count &lt= 1)
                return Empty;
            string [] result = new string[m.Groups[1].Captures.Count];
            int ix = 0;
            foreach(Capture c in m.Groups[1].Captures)
            {
                result[ix++] = c.Value;
            }
            return result;
        }
