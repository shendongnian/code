        string BreakStringIntoLines(string s, int lineWidth)
        {
            StringBuilder sb = new StringBuilder(s);
            for (int i = lineWidth; i < sb.Length; i += lineWidth)
            {
                sb.Insert(i, Environment.NewLine);
            }
            return sb.ToString();
        }
